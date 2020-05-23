using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Abstarct
{
    public interface IProductDal
        : IRepository<Product>
    {
        //List<Product> GetListByListBrand(int[] BrandId);
    }
}
