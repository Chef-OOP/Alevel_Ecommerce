using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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

            try
            {
                #region Ürün Adı Kontrolü
                var pro = await productDal
                    .GetAsync(x => x.Name.ToLower() == product.Name.ToLower());

                if (pro != null)
                    return
                        new EntityResult(ResultType.Info, $"{product.Name} Ürünü Aynı isimde Mevcut");
                #endregion


                #region Ürün Ekleme İşlemi
                int resultDatabase = productDal.Add(product);
                if (resultDatabase > 0)
                    return
                        new EntityResult(ResultType.Success, $"{product.Name} Ürünü Database Kaydedildi");
                else
                    return
                        new EntityResult(ResultType.Warning, "Ürün Ekleme İşlemi Başarısız");
                #endregion

            }
            catch (Exception ex)
            {
                return
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
                        new EntityResult<Product>(null, ResultType.Info, $"{product.Name} Ürünü Aynı isimde Mevcut");
                #endregion

                var result = await productDal.AddProduct(product);

                if (result != null)
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
        public async Task<EntityResult<Product>> GetById(int id)
        {
            try
            {
                var product = await productDal.GetAsync(x => x.Id == id);
                if (productDal != null)
                    return
                        new EntityResult<Product>(product, ResultType.Success);
                return
                    new EntityResult<Product>(null, ResultType.Info, "Aradığınız Ürün bulunamadı");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<Product>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }
        }
        public async Task<EntityResult<List<Product>>> GetList(Expression<Func<Product, bool>> filter = null)
        {
            try
            {
                List<Product> products = await productDal.GetAllAsync(filter);
                return
                    new EntityResult<List<Product>>(products);
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database Hatası -> " + ex.Message);
            }
        }
        public EntityResult Delete(Product product)
        {
            return
                new EntityResult(ResultType.Warning, "Databaseden kalıcı olarak ürün silemezsiniz");
        }
        public async Task<EntityResult> Update(Product model)
        {
            try
            {
                var product =
                    await productDal
                    .GetAsync(x => x.Id != model.Id && x.Name.ToLower() == model.Name.ToLower());
                if (product != null)
                    return
                        new EntityResult(ResultType.Info, "Aynı isimde Ürün Mevcut");

                if (productDal.Update(model) > 0)
                    return new EntityResult(ResultType.Success, "Ürün Basrı ile güncellendi");
                return new EntityResult(ResultType.Warning, "Güncelleme sırasında bir hata oluştu");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult(ResultType.Error, "Database hatası -> " + ex.Message);
            }
        }
        public EntityResult<List<Product>> GetListByListBrand(int[] brand, int[] productProperty)
        {
            try
            {
                var productList = productDal.GetListByListBrand(brand, productProperty);
                if (productList != null)
                    return
                        new EntityResult<List<Product>>(productList, ResultType.Success, "Aranan liste");
                return
                    new EntityResult<List<Product>>(null, ResultType.Info, "Aranan Kriterlere uygun ürün bulunamadı");

            }
            catch (Exception ex)
            {
                return
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database hatası: " + ex.Message);
            }

        }
        public async Task<EntityResult<List<Product>>> GetAdvicedsByCount(int count)
        {
            try
            {
                var productList =
                    await productDal.GetAdvicedsByCount(count);
                if (productList != null)
                    return
                        new EntityResult<List<Product>>(productList, ResultType.Success, "Önerilerimiz Listelendi");
                return
                    new EntityResult<List<Product>>(null, ResultType.Info, "Öneri listemiz şu anda boş");

            }
            catch (Exception ex)
            {
                return
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database Hatası: " + ex.Message);
            }

        }
        public async Task<EntityResult<List<Product>>> GetBestSellingsByCount(int count)
        {
            try
            {
                var sellingList =
                     await productDal.GetBestSellingsByCount(count);
                if (sellingList != null)
                    return
                        new EntityResult<List<Product>>(sellingList, ResultType.Success, "En çok satanlar");
                return
                    new EntityResult<List<Product>>(null, ResultType.Info, "Ençok satanlar listesi boş");

            }
            catch (Exception ex)
            {
                return
                    new EntityResult<List<Product>>(null, ResultType.Error, "Databse Hatası: " + ex.Message);
            }
        }
        public async Task<EntityResult<List<Product>>> GetBrand(int BrandId)
        {
            try
            {
                var productList =
                    await productDal.GetAllAsync(x => x.BrandId == BrandId);
                if (productList != null)
                    return
                        new EntityResult<List<Product>>(productList, ResultType.Success, "Şeçili Markanın Ürünleri");
                return
                    new EntityResult<List<Product>>(null, ResultType.Info, "Seçili Marka ürünleri mevcut değil");
            }
            catch (Exception ex)
            {
                return
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database Katası: " + ex.Message);
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


    }
}
