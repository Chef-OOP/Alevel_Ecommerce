using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class ProductManager
        : IProductService
    {
        private readonly IProductDal productDal;

        public ProductManager(IProductDal productDal)
        {
            this.productDal = productDal;
        }

        public async Task<EntityResult> Add(Product product)
        {
            //TODO : Loglama
            EntityResult result = null;
            try
            {
                #region Ürün Adı Kontrolü
                var pro = await productDal
                    .GetAsync(x => x.Name.ToLower() == product.Name.ToLower());

                if (pro != null)
                    return result =
                         new EntityResult(ResultType.Info, $"{product.Name} Ürünü Aynı isimde Mevcut");
                #endregion


                #region Ürün Ekleme İşlemi
                int resultDatabase = productDal.Add(product);
                if (resultDatabase > 0)
                    return result =
                        new EntityResult(ResultType.Success, $"{product.Name} Ürünü Database Kaydedildi");
                else
                    return result =
                        new EntityResult(ResultType.Warning, "Ürün Ekleme İşlemi Başarısız");
                #endregion

            }
            catch (Exception ex)
            {
                return result =
                     new EntityResult(ResultType.Error, "Database Hatası: -> " + ex.Message);
            }
        }


        public async Task<EntityResult<Product>> AddProduct(Product product)
        {
            try
            {
                #region Ürün Adı Kontrolü
                var pro = await productDal
                    .GetAsync(x => x.Name.ToLower() == product.Name.ToLower());

                if (pro != null)
                    return 
                        new EntityResult<Product>(null,ResultType.Info, $"{product.Name} Ürünü Aynı isimde Mevcut");
                #endregion

                var result = await productDal.AddProduct(product);
                
                 if(result!=null)
                    return 
                        new EntityResult<Product>(result, ResultType.Success, "Ekleme işlemi Başarılı");
                else
                    return
                        new EntityResult<Product>(null, ResultType.Warning, "Ekleme işlemi başarısız");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<Product>(null, ResultType.Error, "Database Hatası -> " + ex.Message);
            }
          
        }

        public EntityResult Delete(Product product)
        {
            return
                new EntityResult(ResultType.Warning, "Databaseden kalıcı olarak ürün silemezsiniz");
        }

        public Task<EntityResult<List<Product>>> GetAdvicedsByCount(int count)
        {
            //TODO : Doldur
            throw new NotImplementedException();
        }

        public Task<EntityResult<List<Product>>> GetBestSellingsByCount(int count)
        {
            throw new NotImplementedException();
        }

        public Task<EntityResult<Product>> GetById(int id)
        {
            //TODO : Doldur
            throw new NotImplementedException();
        }

        public async Task<EntityResult<List<Product>>> GetList(Expression<Func<Product, bool>> filter = null)
        {
            EntityResult<List<Product>> result = null;
            try
            {
                List<Product> products = await productDal.GetAllAsync(filter);
                return result =
                    new EntityResult<List<Product>>(products);
            }
            catch (Exception ex)
            {
                return result =
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database Hatası -> " + ex.Message);
            }
        }

        public async Task<EntityResult<List<Product>>> GetListByCategory(int CategoryId)
        {
            EntityResult<List<Product>> result = null;
            try
            {
                List<Product> products = await productDal.GetAllAsync(x => x.CategoryId == CategoryId);
                return result =
                    new EntityResult<List<Product>>(products);
            }
            catch (Exception ex)
            {
                return result =
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database Hatası -> " + ex.Message);
            }
        }

        public Task<EntityResult<List<Product>>> GetListByListBrand(int[] BrandId)
        {
            //TODO : Doldur
            throw new NotImplementedException();
        }

        public EntityResult<List<Product>> GetListByListBrand(Brand[] brand, ProductProperty[] productProperty)
        {
            //TODO : Doldur
            throw new NotImplementedException();
        }

        public async Task<EntityResult<List<Product>>> GetListDeleted()
        {
            EntityResult<List<Product>> result = null;
            try
            {
                List<Product> products = await productDal.GetAllAsync(x => x.IsDeleted == true);
                return result =
                    new EntityResult<List<Product>>(products);
            }
            catch (Exception ex)
            {
                return result =
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database Hatası -> " + ex.Message);
            }
        }

        public Task<EntityResult> Update(Product model)
        {
            //TODO : Doldur
            throw new NotImplementedException();
        }
    }
}
