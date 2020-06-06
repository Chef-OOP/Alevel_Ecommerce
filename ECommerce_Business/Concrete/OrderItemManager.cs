using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class OrderItemManager : IOrderItemService
    {
        private readonly IOrderItemDal orderItemDal;
        public OrderItemManager(IOrderItemDal _orderItemDal)
        {
            orderItemDal = _orderItemDal;
        }

        public EntityResult Add(OrderItem model)
        {
            try
            {
                if (orderItemDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Ekleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(OrderItem model)
        {
            try
            {
                if (orderItemDal.Delete(model) > 0)
                    return new EntityResult(ResultType.Success, "Silme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Silme işlemi sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<OrderItem>> GetById(int id)
        {
            try
            {
                var orderItem = await orderItemDal.GetAsync(x => x.Id == id);
                if (orderItem != null)
                    return new EntityResult<OrderItem>(orderItem, ResultType.Success);
                return new EntityResult<OrderItem>(null, ResultType.Warning, "Aradınız içerik bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<OrderItem>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<OrderItem>>> GetList(Expression<Func<OrderItem, bool>> filter = null)
        {
            try
            {
                var orderItems = await orderItemDal.GetAllAsync(filter,"Product");
                if (orderItems.Count > 0)
                    return new EntityResult<List<OrderItem>>(orderItems, ResultType.Success);
                return new EntityResult<List<OrderItem>>(orderItems, ResultType.Info, "Hiç içerik bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<OrderItem>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Update(OrderItem model)
        {
            try
            {
                int result = orderItemDal.Update(model) ;
                if (result==1)
                    return new EntityResult(ResultType.Success, "Güncelleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Güncelleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }
    }
}
