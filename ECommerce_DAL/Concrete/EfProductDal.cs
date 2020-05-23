using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public List<Product> GetListByListBrand(Brand[] brand, ProductProperty[] productProperty)
        {

            #region Bunu Testi yapıldı çalışıyor

            List<Product> products = null;

            if (brand.Length > 0)//boş gelirse
            {
                var predicateProduct = PredicateBuilder.False<Product>();
                for (int i = 0; i < brand.Length; i++)
                {
                    int id = brand[i].Id;
                    predicateProduct = predicateProduct.Or(p => p.BrandId == id);
                }
                products = context.Products.Where(predicateProduct).ToList();//Product Listdönüyor 
            }

            #endregion



            #region MyRegion
            List<Product> productList = null;

            if (productProperty.Length > 0)
            {
                var predicateProperty = PredicateBuilder.False<ProductPropertyProduct>();
                for (int i = 0; i < productProperty.Length; i++)
                {
                    int id = productProperty[i].Id;
                    predicateProperty = predicateProperty.Or(p => p.ProductProperty.Id == id);
                }
                productList = context
                    .ProductPropertyProducts
                    .Where(predicateProperty)
                    .Include(x => x.Product)
                    .Select(x => x.Product)
                    .ToList();
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
