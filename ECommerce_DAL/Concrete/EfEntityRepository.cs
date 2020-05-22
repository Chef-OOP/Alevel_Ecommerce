﻿using ECommerce_DAL.Abstarct;
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
        public int Add(TEntity entity)
        {
            Context.Add(entity);
            return Context.SaveChanges();
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
                return await Context.Set<TEntity>().ToListAsync();
            else
                return await Context.Set<TEntity>().Where(filter).ToListAsync();
        }
        public int Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }
        public int Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return Context.SaveChanges();
        }
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
    }
}