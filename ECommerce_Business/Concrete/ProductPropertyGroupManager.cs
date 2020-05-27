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
    public class ProductPropertyGroupManager : IProductPropertyGroupService
    {
        private readonly IProductPropertyGroupDal groupDal;
        public ProductPropertyGroupManager(IProductPropertyGroupDal _groupDal)
        {
            groupDal = _groupDal;
        }

        public async Task<EntityResult> Add(ProductPropertyGroup model)
        {
            try
            {
                var propertyGroup = await groupDal.GetAsync(x => x.Name.ToLower() == model.Name.ToLower());
                if (propertyGroup != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir özellik grubu zaten mevcut");

                if (groupDal.Add(model) > 0)
                    return new EntityResult(ResultType.Success, "Özellik grubu başarıyla eklendi");
                return new EntityResult(ResultType.Warning, "Özellik grubu ekleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public EntityResult Delete(ProductPropertyGroup model)
        {
            return new EntityResult(ResultType.Info, "Özellik grubunu kalıcı olarak kategori silemezsiniz");
        }

        public async Task<EntityResult<ProductPropertyGroup>> GetById(int id)
        {
            try
            {
                var propertyGroup = await groupDal.GetAsync(x => x.Id == id);
                if (propertyGroup != null)
                    return new EntityResult<ProductPropertyGroup>(propertyGroup, ResultType.Success);
                return new EntityResult<ProductPropertyGroup>(null, ResultType.Warning, "Aradığınız özellik grubu bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<ProductPropertyGroup>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<ProductPropertyGroup>>> GetGroupCategory(Category category)
        {
            try
            {
                var result =
                    await groupDal.GetCategoriesGroup(category);
                if (result != null)
                    return
                        new EntityResult<List<ProductPropertyGroup>>(result);
                return
                    new EntityResult<List<ProductPropertyGroup>>(null, ResultType.Info, "Lİstelenemedi");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<List<ProductPropertyGroup>>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult<List<ProductPropertyGroup>>> GetList(Expression<Func<ProductPropertyGroup, bool>> filter = null)
        {
            try
            {
                var propertyGroups = await groupDal.GetAllAsync(filter);
                if (propertyGroups.Count > 0)
                    return new EntityResult<List<ProductPropertyGroup>>(propertyGroups, ResultType.Success);
                return new EntityResult<List<ProductPropertyGroup>>(propertyGroups, ResultType.Info, "Hiç özellik grubu bulunamadı");
            }
            catch (Exception ex)
            {
                return new EntityResult<List<ProductPropertyGroup>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult> Update(ProductPropertyGroup model)
        {
            try
            {
                var propertyGroup = await groupDal.GetAsync(x => x.Id != model.Id && x.Name == model.Name);
                if (propertyGroup != null)
                    return new EntityResult(ResultType.Info, $"{model.Name} isimli bir özellik grubu zaten mevcut");

                if (groupDal.Update(model) > 0)
                    return new EntityResult(ResultType.Success, "Özellik grubu güncelleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Güncelleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

    }
}
