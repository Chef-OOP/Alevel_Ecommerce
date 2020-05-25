using ECommerce_Entity.Constant;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Business.Abstarct
{
    public interface IGenericService<T>
    {
        Task<EntityResult<T>> GetById(int id);
        Task<EntityResult<List<T>>> GetList(Expression<Func<T,bool>> filter = null);
        Task<EntityResult> Add(T model);
        EntityResult Delete(T model);
        Task<EntityResult> Update(T model);
    }
}
