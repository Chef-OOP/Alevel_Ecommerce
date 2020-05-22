using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IProductServis
    {
        Task<EntityResult<List<Product>>> GetList();
        Task<EntityResult<List<Product>>> GetListDeleted();
        EntityResult<List<Product>> GetListByCategory(int CategoryId);
        EntityResult<Product> GetById(int id);
        Task<EntityResult> Add(Product product);
        EntityResult Delete(Product product);  
        EntityResult UpDelete(Product product);  
        EntityResult Update(Product product);
    }
}
