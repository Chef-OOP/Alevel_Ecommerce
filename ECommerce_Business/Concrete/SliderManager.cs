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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal sliderDal;
        public SliderManager(ISliderDal _sliderDal)
        {
            sliderDal = _sliderDal;
        }

        public async Task<EntityResult> Add(Slider model)
        {
            try
            {
                var slider = await sliderDal.GetAsync(x => x.Name.ToLower() == model.Name.ToLower());
                if (slider != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir slider zaten mevcut");

                if (sliderDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Slider başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Slider ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(Slider model)
        {
            return new EntityResult(ResultType.Info, "Veritabanından kalıcı olarak slider silemezsiniz");
        }

        public async Task<EntityResult<Slider>> GetById(int id)
        {
            try
            {
                var slider = await sliderDal.GetAsync(x => x.Id == id);
                if (slider != null)
                    return new EntityResult<Slider>(slider, ResultType.Success);
                return new EntityResult<Slider>(null, ResultType.Warning, "Aradığınız slider bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<Slider>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<Slider>>> GetList(Expression<Func<Slider, bool>> filter = null)
        {
            try
            {
                var sliders = await sliderDal.GetAllAsync(filter);
                if (sliders.Count > 0)
                    return new EntityResult<List<Slider>>(sliders, ResultType.Success);
                return new EntityResult<List<Slider>>(sliders, ResultType.Info, "Hiç slider bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Slider>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult> Update(Slider model)
        {
            try
            {
                var slider = await sliderDal.GetAsync(x => x.Id != model.Id && x.Name == model.Name);
                if (slider != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir slider zaten mevcut");

                if (sliderDal.Update(model) > 0)
                    return new EntityResult(ResultType.Success, "Slider güncelleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Güncelleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        
    }
}
