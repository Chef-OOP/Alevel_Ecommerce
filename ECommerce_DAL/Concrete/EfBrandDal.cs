using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    public class EfBrandDal : EfEntityRepository<Brand, ECommerceContext>, IBrandDal
    {
        private readonly ECommerceContext context;
        public EfBrandDal(ECommerceContext context) : base(context)
        {
            this.context = context;
        }
        public List<Brand> Brands(List<Product> products)
        {
            var brands = from p in (products.Select(x => x.BrandId).Distinct())
                         from b in context.Brands
                         where b.Id == p
                         select b;
            return brands.ToList();


        }
    }
}
