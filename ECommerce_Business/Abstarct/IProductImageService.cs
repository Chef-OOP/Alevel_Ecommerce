using ECommerce_Entity.Concrete.POCO;
using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IProductImageService
    {
        Task<EntityResult<ProductImage>> GetById(int id);
        Task<EntityResult<List<ProductImage>>> GetList(Expression<Func<ProductImage,bool>> filter = null);
        Task<EntityResult> Add(ProductImage model);
        EntityResult Delete(ProductImage model);
    }
}
