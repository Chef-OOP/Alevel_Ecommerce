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


        //public List<Product> GetListByListBrand(int[] BrandId, int[] Properties)
        //{
        //    List<Product> listProduct = null;

        //    if (BrandId.Length > 0)
        //    {
        //        var result = "select * from Product where ";
        //        for (int i = 0; i < BrandId.Length; i++)
        //        {
        //            result += $"BrandId= '{BrandId[i]}' or ";
        //        }
        //        result = result.Remove(result.Length - 4);
        //        listProduct = context.Products.FromSqlRaw(result).ToList();
        //    }
        //    else
        //    {
        //        listProduct = context.Products.ToList();
        //    }

        //    var predicate = PredicateBuilder.False<Foo>();
        //    predicate = predicate.Or(f => f.A == 1);
        //    if (allowB)
        //    {
        //        predicate = predicate.Or(f => f.B == 1);
        //    }

        //    var query = collection.Where(predicate);

            //    List<Product> l = new List<Product>();

            //    for (int i = 0; i < listProduct.Count; i++)
            //    {
            //        bool bul = false;
            //        for (int j = 0; j < listProduct[i].Properties.Count; j++)
            //        {
            //            for (int k = 0; k < Properties.Length; k++)
            //            {
            //                if (Properties[k] == listProduct[i].Properties[j].Id)
            //                {
            //                    l.Add(listProduct[i]);
            //                    bul = true;
            //                    break;
            //                }
            //            }
            //            if (bul)
            //            {
            //                break;
            //            }
            //        }
            //    }

            //    return listProduct;
            //}

        //}

    }
}
