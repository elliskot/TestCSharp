using System.Data.Entity;
using TestCSharp.DataAccess.Interfaces;
using TestCSharp.Models;
using TestCSharp.Models.Entities;

namespace TestCSharp.DataAccess
{
    public abstract class DatabaseFactory<Y> : DatabaseFactoryBase<Y>
        where Y : ContextBase
    {
        protected Y _oDataContext = null;

        public DatabaseFactory(string contextName)
            : base(contextName) {

        }

        public abstract Y InstanceContext(string contextName);
        public override Y GetContext() {
            if (_oDataContext == null) {
                _oDataContext = InstanceContext(this._sName);    
            }
            return _oDataContext;
        }

        protected override void DisposeCore() {
            if (_oDataContext != null)
                _oDataContext.Dispose();
        }
    }
}
