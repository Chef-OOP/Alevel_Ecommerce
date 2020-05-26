using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using MoreLinq.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfProductDal
        : EfEntityRepository<Product, ECommerceContext>, IProductDal
    {
        private readonly ECommerceContext context;

        public EfProductDal(ECommerceContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
            var result = await context.AddAsync(product);
            await context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<List<Product>> GetAdvicedsByCount(int count)
        {
            return await context.Products.Where(x => x.IsAdviced).Take(count).ToListAsync();
        }

        public async Task<List<Product>> GetBestSellingsByCount(int count)
        {
            return await context.Products.OrderByDescending(x => x.Selling).Take(count).ToListAsync();
        }

        public List<Product> GetListByListBrand(int[] brand, int[] productProperty)
        {

            #region Bunu Testi yapıldı çalışıyor

            List<Product> products = null;

            if (brand.Length > 0)//boş gelirse
            {
                var predicateProduct = PredicateBuilder.False<Product>();
                for (int i = 0; i < brand.Length; i++)
                {
                    int id = brand[i];
                    predicateProduct = predicateProduct.Or(p => p.BrandId == id);
                }
                products = context.Products.Where(predicateProduct).ToList();//Product Listdönüyor 
            }

            #endregion


            #region MyRegion
            List<Product> productList = new List<Product>();

            if (productProperty.Length > 0)
            {
                var predicateProperty = PredicateBuilder.False<ProductPropertyProduct>();
                for (int i = 0; i < productProperty.Length; i++)
                {
                    int id = productProperty[i];
                    predicateProperty = predicateProperty.Or(p => p.ProductProperty.Id == id);
                }
                productList = context
                    .ProductPropertyProducts
                    .Where(predicateProperty)
                    .Include(x => x.Product)
                    .Select(x => x.Product)
                    .DistinctBy(x => x.Id)
                    .ToList();

                // distinctby 188 ms
                //productList = productList.ToList();
            }
            #endregion



            #region MyRegion
            if (brand.Length > 0 && productProperty.Length > 0) //productProperty dolu brand dolu gelirse ihtimali
            {
                List<Product> products1 = (from p in products
                                           from pl in productList
                                           where p.Id == pl.Id
                                           select p).ToList();
                return products1;
            }

            if (brand.Length > 0) //productProperty boş brand dolu gelirse ihtimali
            {
                return products;
            }
            if (productProperty.Length > 0) //productProperty dolu brand boş gelirse ihtimali
            {
                return productList;
            }
            return null;
            #endregion
        }




    }
}
