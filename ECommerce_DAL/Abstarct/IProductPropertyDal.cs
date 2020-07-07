using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Abstarct
{
    public interface IProductPropertyDal: IRepository<ProductProperty>
    {
        Task<List<ProductProperty>> GetListByProductId(int productId);
    }
}
