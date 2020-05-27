using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class ProductPropertyProductsManager
        : IProductPropertyProductsService
    {
        private readonly IProductPropertyProductsDal productPropertyProductsDal;

        public ProductPropertyProductsManager(IProductPropertyProductsDal productPropertyProductsDal)
        {
            this.productPropertyProductsDal = productPropertyProductsDal;
        }
        public async Task<EntityResult> Add(ProductPropertyProduct model)
        {
            try
            {
                var productPropertProduct = await productPropertyProductsDal
                .GetAsync(x => x.ProductId == model.ProductId &&
                x.ProductPropertyId == model.ProductPropertyId);
                if (productPropertProduct != null)
                    return new EntityResult(ResultType.Info, "Tabloda bu ilişki daha önce kurulmuş");

                if (productPropertyProductsDal.Add(model) > 0)
                    return
                        new EntityResult(ResultType.Success, "Ekleme işlemi başarılı");
                return new EntityResult(ResultType.Warning, "Ekleme işlemi başarısız");
            }
            catch (Exception ex)
            {
                return new EntityResult(ResultType.Error, "Database Hatası -> " + ex.Message);
            }
        }

        public EntityResult Delete(ProductPropertyProduct model)
        {
            try
            {
                var result = productPropertyProductsDal.Delete(model);
                if (result > 0)
                    return
                        new EntityResult();
                return new EntityResult(ResultType.Info, "Silme işlemi başarısız");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult(ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public Task<EntityResult<ProductPropertyProduct>> GetById(int id)
        {
            //TODO : Çoka çok ara tabloda gerek yok
            throw new NotImplementedException();
        }

        public async Task<EntityResult<List<ProductPropertyProduct>>> GetList(Expression<Func<ProductPropertyProduct, bool>> filter = null)
        {
            try
            {
                var result =
                    await productPropertyProductsDal.GetAllAsync();
                if (result != null)
                    return
                        new EntityResult<List<ProductPropertyProduct>>(result);
                return
                    new EntityResult<List<ProductPropertyProduct>>(null, ResultType.Info, "Lİsteleme işlemi başarısız");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<List<ProductPropertyProduct>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }

        public async Task<EntityResult> Update(ProductPropertyProduct model)
        {
            try
            {
                var property =
                    await productPropertyProductsDal.
                    GetAsync(x => x.ProductId == model.ProductId && x.ProductPropertyId == model.ProductPropertyId);
                if (property != null)
                    return
                        new EntityResult(ResultType.Info, "Seçili eşleştime daha çnceden yapılmış");
                return
                    new EntityResult(ResultType.Warning, "Güncelleme İşlemi başarılı değil");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult(ResultType.Error, "Datbase Hatası: " + ex.Message);
            }
        }
    }
}
