﻿using ECommerce_Business.Abstarct;
using ECommerce_DAL.Abstarct;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Concrete
{
    public class ProductManager
        : IProductServis
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

        public EntityResult Delete(Product product)
        {
            EntityResult result = new EntityResult(ResultType.Warning, "Databaseden kalıcı olarak ürün silemzsiniz");
            return result;
        }

        public EntityResult<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<EntityResult<List<Product>>> GetList()
        {
            EntityResult<List<Product>> result = null;
            try
            {
                List<Product> products = await productDal.GetAllAsync();
                return result =
                    new EntityResult<List<Product>>(products);
            }
            catch (Exception ex)
            {
                return result =
                    new EntityResult<List<Product>>(null, ResultType.Error, "Database Hatası -> " + ex.Message);
            }
        }

        public EntityResult<List<Product>> GetListByCategory(int CategoryId)
        {
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

        public EntityResult Update(Product product)
        {
            throw new NotImplementedException();
        }

        public EntityResult UpDelete(Product product)
        {
            EntityResult result = null;
            try
            {
                product.IsDeleted = true;
                var databaseResult = productDal.UpDelete(product);
                if (databaseResult > 0)
                    return result =
                        new EntityResult(ResultType.Success, $"{product.Name} Ürünü Silindi");
                else
                    return result =
                        new EntityResult(ResultType.Warning, "Silme İşlemi Başarısız");

            }
            catch (Exception ex)
            {
                return result =
                    new EntityResult(ResultType.Error, "Database Hatası -> " + ex.Message);
            }
        }
    }
}