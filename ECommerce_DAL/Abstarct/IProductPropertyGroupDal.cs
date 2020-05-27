using ECommerce_Entity.Concrete.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Abstarct
{
    public interface IProductPropertyGroupDal : IRepository<ProductPropertyGroup>
    {
        Task<List<ProductPropertyGroup>> GetCategoriesGroup(Category model);
    }
}
