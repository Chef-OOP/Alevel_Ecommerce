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
    public class MasterCategoryManager : IMasterCategoryService
    {
        private readonly IMasterCategoryDal masterCategoryDal;
        public MasterCategoryManager(IMasterCategoryDal _masterCategoryDal)
        {
            masterCategoryDal = _masterCategoryDal;
        }

        public async Task<EntityResult> Add(MasterCategory model)
        {
            try
            {
                var masterCategory = await masterCategoryDal.GetAsync(x => x.Name.ToLower() == model.Name.ToLower());
                if (masterCategory != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir kategori zaten mevcut");

                if (masterCategoryDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Üst kategori başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Üst kategori ekleme başarısız");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(MasterCategory model)
        {
            return new EntityResult(ResultType.Info, "Veritabanından kalıcı olarak üst kategori silemezsiniz");
        }

        public async Task<EntityResult<MasterCategory>> GetById(int id)
        {
            try
            {
                var masterCategory = await masterCategoryDal.GetAsync(x => x.Id == id);
                if (masterCategory != null)
                    return new EntityResult<MasterCategory>(masterCategory, ResultType.Success);
                return new EntityResult<MasterCategory>(null, ResultType.Info, "Aradığınız üst kategori bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<MasterCategory>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<MasterCategory>>> GetList(Expression<Func<MasterCategory, bool>> filter = null)
        {
            try
            {
                var masterCategories = await masterCategoryDal.GetAllAsync(filter,"Categories");
                if (masterCategories.Count > 0)
                    return new EntityResult<List<MasterCategory>>(masterCategories, ResultType.Success);
                return new EntityResult<List<MasterCategory>>(masterCategories, ResultType.Info, "Üst kategori bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<MasterCategory>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult> Update(MasterCategory model)
        {
            try
            {
                var category = 
                    await masterCategoryDal
                    .GetAsync(x => x.Id != model.Id && x.Name.ToLower() == model.Name.ToLower());
                if (category != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir üst kategori zaten mevcut");

                if (masterCategoryDal.Update(model) > 0)
                    return new EntityResult(ResultType.Success, "Üst kategori güncelleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Güncelleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

       
    }
}
