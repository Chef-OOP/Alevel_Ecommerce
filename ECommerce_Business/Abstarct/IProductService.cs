using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IProductService : IGenericService<Product>
    {
        
        Task<EntityResult<List<Product>>> GetListDeleted();
        Task<EntityResult<List<Product>>> GetListByCategory(int CategoryId);
        Task<EntityResult<List<Product>>> GetBrand(int BrandId);
        Task<EntityResult<Product>> AddProduct(Product product);
        EntityResult<List<Product>> GetListByListBrand(int[] brand, int[] productProperty);
        Task<EntityResult<List<Product>>> GetBestSellingsByCount(int count);
        Task<EntityResult<List<Product>>> GetAdvicedsByCount(int count);
    }
}
