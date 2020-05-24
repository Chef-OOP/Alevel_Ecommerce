using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IOrderItemService
    {
        Task<EntityResult<OrderItem>> GetById(int id);
        Task<EntityResult<List<OrderItem>>> GetList(Expression<Func<OrderItem,bool>> filter = null);
        EntityResult Add(OrderItem model);
        EntityResult Delete(OrderItem model);
        EntityResult Update(OrderItem model);
    }
}
