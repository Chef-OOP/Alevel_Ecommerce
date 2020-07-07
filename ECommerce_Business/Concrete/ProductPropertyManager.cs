using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class ProductPropertyManager : IProductPropertyService
    {
        private readonly IProductPropertyDal propertyDal;
        public ProductPropertyManager(IProductPropertyDal _propertyDal)
        {
            propertyDal = _propertyDal;
        }

        public async Task<EntityResult> Add(ProductProperty model)
        {
            try
            {
                var property = await propertyDal.GetAsync(x => x.Value.ToLower() == model.Value.ToLower() && x.GroupId == model.GroupId);
                if (property != null)
                    return new EntityResult(ResultType.Info, $"Seçmiş olduğunuz grupta {model.Value} isimli bir özellik zaten mevcut");

                if (propertyDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Özellik başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Özellik ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(ProductProperty model)
        {
            try
            {
                if (propertyDal.Delete(model) > 0)
                    return new EntityResult(ResultType.Success, "Özellik başarıyla silindi");
                return new EntityResult(ResultType.Warning, "Özellik silme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<ProductProperty>> GetById(int id)
        {
            try
            {
                var property = await propertyDal.GetAsync(x => x.Id == id);
                if (property != null)
                    return new EntityResult<ProductProperty>(property, ResultType.Success);
                return new EntityResult<ProductProperty>(null, ResultType.Warning, "Aradığınız kategori bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<ProductProperty>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<ProductProperty>>> GetList(Expression<Func<ProductProperty, bool>> filter = null)
        {
            try
            {
                var properties = await propertyDal.GetAllAsync(filter);
                if (properties.Count > 0)
                    return new EntityResult<List<ProductProperty>>(properties, ResultType.Success);
                return new EntityResult<List<ProductProperty>>(properties, ResultType.Info, "Hiç özellik bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<ProductProperty>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<ProductProperty>>> GetListByProductId(int productId)
        {
            try
            {
                var properties = await propertyDal.GetListByProductId(productId);
                if (properties.Count > 0)
                    return new EntityResult<List<ProductProperty>>(properties, ResultType.Success);
                return new EntityResult<List<ProductProperty>>(properties, ResultType.Info, "Hiç özellik bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<ProductProperty>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult> Update(ProductProperty model)
        {
            try
            {
                var property = await propertyDal.GetAsync(x => x.Value.ToLower() == model.Value.ToLower() && x.GroupId == model.GroupId);
                if (property != null)
                    return new EntityResult(ResultType.Info, $"Seçmiş olduğunuz grupta {model.Value} isimli bir özellik zaten mevcut");

                if (propertyDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Özellik başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Özellik ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

      
    }
}
