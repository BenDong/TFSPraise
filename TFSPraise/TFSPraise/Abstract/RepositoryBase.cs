using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TFSPraise.Concrete;
using System.Data.Entity;

namespace TFSPraise.Abstract
{
    public abstract class RepositoryBase<TEntity> where TEntity:class
    {
        protected DbContext Context { get; set; }

        //Set default DbContext as TFSPraiseContext
        public RepositoryBase():this(new TFSPraiseContext())
        {

        }
        public RepositoryBase(DbContext context)
        {
            Context = context;
        }
        public virtual IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
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