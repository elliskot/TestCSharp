using System;
using System.Data.Entity;
using System.Web;
using TestCSharp.DataAccess;
using TestCSharp.DataAccess.Interfaces;
using TestCSharp.Models.Entities;
using TestCSharp.Models;

namespace TestCSharp.DataAccess
{
    public abstract class WebDatabaseFactory<Y> : DatabaseFactoryBase<Y>
        where Y : ContextBase
    {
        public WebDatabaseFactory(string contextName)
            : base(contextName) {
        }

        public abstract Y InstanceContext(string contextName);
        public override Y GetContext() {
            object oValue = HttpContext.Current.Items[this._sName];
            if (oValue == null) {
                oValue = InstanceContext(this._sName);   
                HttpContext.Current.Items[this._sName] = (Y)oValue;
            }
            return (Y)oValue;
        }

        protected override void DisposeCore() {
            object oValue = HttpContext.Current.Items[this._sName];
            if (oValue != null) {
                ((Y)oValue).Dispose();
                HttpContext.Current.Items.Remove(this._sName);
            }
        }

    }
}
