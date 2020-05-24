using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IProductServis : IGenericService<Product>
    {
        
        Task<EntityResult<List<Product>>> GetListDeleted();
        EntityResult<List<Product>> GetListByCategory(int CategoryId);

        //EntityResult<List<Product>> GetListByBrand(int BrandId);
        Task<EntityResult<List<Product>>> GetListByListBrand(int[] BrandId);
        //EntityResult<List<Product>> GetListFilter(int[] PropertyId);
    }
}
