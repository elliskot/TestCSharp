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
    public abstract class Repository<T, Y> : IRepository<T>
        where T : class
        where Y : ContextBase
    {
        private Y _oDataContext;
        private readonly IDbSet<T> _oDbSet;

        public Repository(IDatabaseFactory<Y> databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _oDbSet = DataContext.Set<T>();
        }

        protected IDatabaseFactory<Y> DatabaseFactory {
            get;
            private set;
        }

        protected IDbSet<T> DbSet {
            get { return _oDbSet; }
        }

        protected Y DataContext {
            get { return _oDataContext ?? (_oDataContext = DatabaseFactory.GetContext()); }
        }

        public abstract IQueryable<T> Get();

    }
}