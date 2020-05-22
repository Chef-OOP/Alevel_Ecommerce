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
    public class EfCategoryDal
        : EfEntityRepository<Category, ECommerceContext>,ICategoryDal
    {
        public EfCategoryDal(ECommerceContext context) : base(context)
        {
        }
    }
}
