using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Concrete;
using System.Data.Entity;
using TFSPraise.Entities;
using System.Security.Principal;

namespace TFSPraise.Abstract
{
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Context { get; set; }

        public RepositoryBase() : this(new TFSPraiseContext()) //Set default DbContext as TFSPraiseContext
        {
           
        }

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Asbstract class doesn't support contravariant, to define one 
        /// </summary>
        /// <typeparam name="T">Inherit type</typeparam>
        /// <returns></returns>
        public T Contravariant<T>() where T: RepositoryBase<TEntity>
        {
            return (T)this;
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> condition)
        {
            return GetAll().Where(condition);
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            Context.SaveChanges();
        }
    }
}