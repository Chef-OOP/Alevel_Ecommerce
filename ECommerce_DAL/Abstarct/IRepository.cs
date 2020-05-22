using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Abstarct
{
    /// <summary>
    /// Temel CURD işlemleri için oluşturulmuş BaseRepo interfacesi
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable
    {
        int Add(T entity);
        int Delete(T entity);
        int Update(T entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter = null);
    }
}
