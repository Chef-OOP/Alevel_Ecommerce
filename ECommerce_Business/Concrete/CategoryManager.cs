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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal _categoryDal)
        {

        }

        public async Task<EntityResult> Add(Category model)
        {
            try
            {
                var category = await categoryDal.GetAsync(x => x.Name.ToLower() == model.Name.ToLower());
                if (category != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir kategori zaten mevcut");

                if (categoryDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Kategori başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Kategori ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(Category model)
        {
            return new EntityResult(ResultType.Info, "Veritabanından kalıcı olarak kategori silemezsiniz");
        }

        public async Task<EntityResult<Category>> GetById(int id)
        {
            try
            {
                var category = await categoryDal.GetAsync(x => x.Id == id);
                if (category != null)
                    return new EntityResult<Category>(category, ResultType.Success);
                return new EntityResult<Category>(null, ResultType.Warning, "Aradığınız kategori bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<Category>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<Category>>> GetList(Expression<Func<Category,bool>> filter = null)
        {
            try
            {
                var categories = await categoryDal.GetAllAsync(filter);
                if (categories.Count > 0)
                    return new EntityResult<List<Category>>(categories, ResultType.Success);
                return new EntityResult<List<Category>>(categories, ResultType.Info, "Hiç kategori bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Category>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult> Update(Category model)
        {
            try
            {
                var category = await categoryDal.GetAsync(x => x.Id != model.Id && x.Name == model.Name);
                if (category != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir kategori zaten mevcut");

                if (categoryDal.Update(model) > 0)
                    return new EntityResult(ResultType.Success, "Kategori güncelleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Güncelleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

       
    }
}
