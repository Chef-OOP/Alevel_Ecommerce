using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal brandDal;
        public BrandManager(IBrandDal _brandDal)
        {
            brandDal = _brandDal;
        }
        public async Task<EntityResult> Add(Brand model)
        {
            try
            {
                var brand = await brandDal.GetAsync(x => x.Name.ToLower() == model.Name.ToLower());
                if (brand!=null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir marka zaten mevcut");

                if (brandDal.Add(model)>0)
                    return new EntityResult(ResultType.Success, "Marka başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Marka ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: "+ex.Message);
            }
        }

        public EntityResult Delete(Brand model)
        {
            try
            {
                if (brandDal.Delete(model) > 0)
                    return new EntityResult(ResultType.Success, "Marka başarıyla silindi");
                return new EntityResult(ResultType.Warning, "Marka silme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<Brand>> GetById(int id)
        {
            try
            {
                var brand = await brandDal.GetAsync(x => x.Id == id);
                if (brand != null)
                    return new EntityResult<Brand>(brand, ResultType.Success);
                return new EntityResult<Brand>(null, ResultType.Warning, "Aradığınız ürün bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<Brand>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<Brand>>> GetList(Expression<Func<Brand, bool>> filter = null)
        {
            try
            {
                var brands = await brandDal.GetAllAsync(filter);
                if (brands.Count > 0)
                    return new EntityResult<List<Brand>>(brands, ResultType.Success);
                return new EntityResult<List<Brand>>(brands, ResultType.Info, "Hiç marka bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Brand>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult> Update(Brand model)
        {
            try
            {
                var brand = await brandDal.GetAsync(x => x.Id != model.Id && x.Name == model.Name);
                if (brand != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir marka zaten mevcut");

                if (brandDal.Update(model) > 0)
                    return new EntityResult(ResultType.Success, "Marka güncelleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Güncelleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        
    }
}
