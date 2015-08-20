using System.Data.Entity;
using TestCSharp.DataAccess.Interfaces;
using TestCSharp.Models;
using TestCSharp.Models.Entities;

namespace TestCSharp.DataAccess
{
    public abstract class DatabaseFactoryBase<Y> : Disposable, IDatabaseFactory<Y>
        where Y : ContextBase
    {
        protected string _sName;

        public abstract Y GetContext();
        protected abstract override void DisposeCore();

        public DatabaseFactoryBase(string contextName)
            : base() {
            this._sName = contextName;
        }
    }
}
