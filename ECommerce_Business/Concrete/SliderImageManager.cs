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
    public class SliderImageManager : ISliderImageService
    {
        private readonly ISliderImageDal imageDal;
        public SliderImageManager(ISliderImageDal _imageDal)
        {
            imageDal = _imageDal;
        }

        public async Task<EntityResult> Add(SliderImage model)
        {
            try
            {
                var sliderImage = await imageDal.GetAsync(x => x.Path.ToLower() == model.Path.ToLower());
                if (sliderImage != null)
                    return new EntityResult(ResultType.Info, $"{model.Path} yolunda aynı isimli bir dosya zaten mevcut");

                if (imageDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Resim başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Resim ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

      
        public EntityResult Delete(SliderImage model)
        {
            try
            {
                if (imageDal.Delete(model) > 0)
                    return new EntityResult(ResultType.Success, "Resim başarıyla silindi");
                return new EntityResult(ResultType.Warning, "Resim silme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<SliderImage>> GetById(int id)
        {
            try
            {
                var sliderImage = await imageDal.GetAsync(x => x.Id == id);
                if (sliderImage != null)
                    return new EntityResult<SliderImage>(sliderImage, ResultType.Success);
                return new EntityResult<SliderImage>(null, ResultType.Warning, "Aradığınız resim bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<SliderImage>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<SliderImage>>> GetList(Expression<Func<SliderImage, bool>> filter = null)
        {
            try
            {
                var productImages = await imageDal.GetAllAsync(filter);
                if (productImages.Count > 0)
                    return new EntityResult<List<SliderImage>>(productImages, ResultType.Success);
                return new EntityResult<List<SliderImage>>(productImages, ResultType.Info, "Hiç resim bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<SliderImage>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }
    }
}
