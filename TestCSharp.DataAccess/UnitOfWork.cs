using System.Data.Entity;
using TestCSharp.DataAccess.Interfaces;
using TestCSharp.Models;
using TestCSharp.Models.Entities;

namespace TestCSharp.DataAccess
{
    public class UnitOfWork<Y> : IUnitOfWork
        where Y : ContextBase
    {
        private readonly IDatabaseFactory<Y> _oDbFactory;
        private Y _oDataContext;

        public UnitOfWork(IDatabaseFactory<Y> databaseFactory)
        {
            this._oDbFactory = databaseFactory;
        }

        protected Y DataContext
        {
            get { return _oDataContext ?? (_oDataContext = _oDbFactory.GetContext()); }
        }

        public void Commit()
        {
            DataContext.Commit();
        }
    }
}
