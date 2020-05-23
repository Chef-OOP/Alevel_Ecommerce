using ECommerce_DAL.Concrete;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // Brand[] brands1 = new Brand[]//database
            // {
            //     new Brand(){ Id=1, Name="Arçelik"},
            //     new Brand(){ Id=2, Name="Beko"},
            //     new Brand(){ Id=3, Name="Sony"},
            //     new Brand(){ Id=4, Name="Samsung"},
            //     new Brand(){ Id=5, Name="Ericson"},
            //     new Brand(){ Id=6, Name="Nokia"},
            // };
            // Brand[] brands = new Brand[]//kullanıcıdan gelen liste
            //{
            //     new Brand(){ Id=1, Name="Arçelik"},
            //     new Brand(){ Id=2, Name="Beko"}
            //};

            // List<Product> products = new List<Product>//ürün tablosu
            // {
            //     new Product(){Id=1, Name="pro1", BrandId=1},
            //     new Product(){Id=2, Name="pro2", BrandId=6},
            //     new Product(){Id=3, Name="pro3", BrandId=3},
            //     new Product(){Id=4, Name="pro4", BrandId=1},
            //     new Product(){Id=5, Name="pro5", BrandId=2},
            //     new Product(){Id=6, Name="pro6", BrandId=6},
            //     new Product(){Id=8, Name="pro7", BrandId=4},
            //     new Product(){Id=9, Name="pro8", BrandId=5},
            //     new Product(){Id=10, Name="pro9", BrandId=4},
            //     new Product(){Id=11, Name="pro0", BrandId=6},
            //     new Product(){Id=12, Name="pro11", BrandId=3},
            // };

            // var predicateProduct = PredicateBuilder.False<Product>();

            // #region Çalıştı
            // //predicateProduct = predicateProduct.Or(p => p.BrandId == 1);
            // //predicateProduct = predicateProduct.Or(p => p.BrandId == 2);
            // //predicateProduct = predicateProduct.Or(p => p.BrandId == 5);
            // //var result = products.AsQueryable().Where(predicateProduct).ToList();

            // //foreach (var item in result)
            // //{
            // //    Console.WriteLine(item.Name);
            // //}
            // #endregion

            // #region Çalıştı

            // for (int i = 0; i < brands.Length; i++)
            // {
            //     int a = brands[i].Id;
            //     predicateProduct = predicateProduct.Or(p => p.BrandId == a);
            // }
            // var result = products.AsQueryable().Where(predicateProduct).ToList();

            // foreach (var item in result)
            // {
            //     Console.WriteLine(item.Name);
            // }
            // #endregion



            // #region Test

            // //ProductPropertyGroup group = new ProductPropertyGroup
            // //{
            // //    Name = "Aroma"
            // //};
            // //ProductProperty pp = new ProductProperty
            // //{
            // //    Value = "Tavuklu",
            // //   Group = group
            // //};

            // //Category c = new Category
            // //{
            // //    Name = "Kedi maması"
            // //};

            // ////c.PropertyGroups.Add(group);

            // //Product p = new Product
            // //{
            // //    Name = "En iyi kedi maması",
            // //    Category = c
            // //};

            // //p.Properties.Add(pp); 
            // #endregion

            EfProductDal pDal = new EfProductDal(new ECommerceContext());

            var brands = new Brand[] { new Brand { Id = 1 }, new Brand { Id = 2 } };
            var pp = new ProductProperty[] {new ProductProperty { Id = 5 } };
            var products = pDal.GetListByListBrand(brands, pp);
        }
    }

}
