using ECommerce_DAL.Abstarct;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_DAL.Concrete
{
    /// <summary>
    /// Entity Framework altyapısı için oluşturulmuş temel CURD işlemleri için BaseRepo sınıfı
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TContext">Entityframework base class</typeparam>
    public class EfEntityRepository<TEntity, TContext>
        : IRepository<TEntity>
        where TEntity : class
        where TContext : Microsoft.EntityFrameworkCore.DbContext

    {
        protected readonly TContext Context;
        public EfEntityRepository(TContext context)
        {
            Context = context;
        }
        /// <summary>
        /// Entity Ekler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Add(TEntity entity)
        {
            Context.Add(entity);
            return Context.SaveChanges();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }
        /// <summary>
        /// Tüm Sorgu methodları bu method üzerinde gidecek
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null,params string[] includeItems)
        {
            IQueryable<TEntity> result = null;
            if (filter == null)
                result = Context.Set<TEntity>().AsQueryable();
            else
                result = Context.Set<TEntity>().AsQueryable().Where(filter);

            if (includeItems!=null)
            {
                foreach (var item in includeItems)
                {
                    result = result.Include(item);
                }
            }

            return await result.ToListAsync();
        }
        /// <summary>
        /// Database desilimsi gereken dosyaları siler
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            return Context.SaveChanges();
        }
        /// <summary>
        /// Databasede silinmemesi gereken ancak kullanıcının silemeye çalıştığı dosyalar
        /// NOT : Entity class larının içinden gelecek olan bool IsDeleted true işaretleyecek 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpDelete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }
        /// <summary>
        /// Güncellme Yapar
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update(TEntity entity)
        {
            //Context.Set<TEntity>().Attach(entity);
            //string a = Context.Entry(entity).State.ToString();
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();

            //Context.Set<TEntity>().AddOrUpdate()
        }


        #region GC iş bırakmayan Yerdir  Bura
        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!Disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
                //Unmanaged resource    
                Disposed = true;
            }
        }
        private bool Disposed { get; set; }

        #endregion
    }
}
