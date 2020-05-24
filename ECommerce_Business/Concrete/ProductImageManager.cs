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
    public class ProductImageManager
    {
        private readonly IProductImageDal productImageDal;
        public ProductImageManager(IProductImageDal _productImageDal)
        {
            productImageDal = _productImageDal;
        }

        public async Task<EntityResult> Add(ProductImage model)
        {
            try
            {
                var productImage = await productImageDal.GetAsync(x => x.Path.ToLower() == model.Path.ToLower());
                if (productImage != null)
                    return new EntityResult(ResultType.Info, $"{model.Path} yolunda aynı isimli bir dosya zaten mevcut");

                if (productImageDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Resim başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Resim ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(ProductImage model)
        {
            try
            {
                if (productImageDal.Delete(model) > 0)
                    return new EntityResult(ResultType.Success, "Resim başarıyla silindi");
                return new EntityResult(ResultType.Warning, "Resim silme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<ProductImage>> GetById(int id)
        {
            try
            {
                var productImage = await productImageDal.GetAsync(x => x.Id == id);
                if (productImage != null)
                    return new EntityResult<ProductImage>(productImage, ResultType.Success);
                return new EntityResult<ProductImage>(null, ResultType.Warning, "Aradığınız resim bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<ProductImage>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<ProductImage>>> GetList(Expression<Func<ProductImage, bool>> filter = null)
        {
            try
            {
                var productImages = await productImageDal.GetAllAsync(filter);
                if (productImages.Count > 0)
                    return new EntityResult<List<ProductImage>>(productImages, ResultType.Success);
                return new EntityResult<List<ProductImage>>(productImages, ResultType.Info, "Hiç resim bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<ProductImage>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }
    }
}
