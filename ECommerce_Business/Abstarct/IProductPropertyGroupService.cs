using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IProductPropertyGroupService:IGenericService<ProductPropertyGroup>
    {
        Task<EntityResult<List<ProductPropertyGroup>>> GetGroupCategory(Category category);
    }
}
