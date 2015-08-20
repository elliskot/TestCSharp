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

    public abstract class ReadOnlyRepository<T, Y> : Repository<T, Y>, 
        IReadOnlyRepository<T>
        where T : class
        where Y : ContextBase
    {

        public ReadOnlyRepository(IDatabaseFactory<Y> databaseFactory)
            : base(databaseFactory)
        {
        }

        protected abstract IQueryable<T> ApplySecurityOnRead(IQueryable<T> query);

        public IQueryable<T> Get() {
            IQueryable<T> oQueryable = this.Get();
            oQueryable = this.ApplySecurityOnRead(oQueryable);
            return oQueryable;
        }

    }
}