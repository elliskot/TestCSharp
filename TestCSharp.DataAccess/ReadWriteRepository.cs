using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using TestCSharp.DataAccess.Interfaces;
using TestCSharp.Models;
using TestCSharp.Models.Entities;

namespace TestCSharp.DataAccess
{
    public abstract class ReadWriteRepository<T, Y> : Repository<T, Y>,
        IReadWriteRepository<T>
        where T : class
        where Y : ContextBase
    {
        
        public ReadWriteRepository(IDatabaseFactory<Y> databaseFactory)
            : base(databaseFactory)
        {
        }

        protected abstract IQueryable<T> ApplySecurityOnWrite(IQueryable<T> query);
        public abstract IQueryable<T> GetEdit();

        public virtual void Add(T entity) {
            this.DbSet.Add(entity);
        }
        public virtual void Update(T entity) {
            this.DbSet.Attach(entity);
            this.DataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public virtual void Delete(T entity) {
            this.DbSet.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where) {
            IEnumerable<T> objects = this.DbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                this.DbSet.Remove(obj);
        }

    }
}