using ECommerce_DAL.Abstarct;
using ECommerce_DAL.Concrete.Context;
using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce_DAL.Concrete
{
    public class EfBrandDal : EfEntityRepository<Brand,ECommerceContext>,IBrandDal
    {
        public EfBrandDal(ECommerceContext context) : base(context)
        {

        }
    }
}
