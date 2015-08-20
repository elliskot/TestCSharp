using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCSharp.Models.Entities;

namespace TestCSharp.WebSite.Base.DataAccess
{
    public class WebDatabaseFactory
        : TestCSharp.DataAccess.WebDatabaseFactory<TestCSharpContext>
    {
        public WebDatabaseFactory(string contextName)
            : base(contextName)
        {

        }

        public override TestCSharpContext InstanceContext(string contextName)
        {
            TestCSharpContext oNewContext = new TestCSharpContext(contextName);
            return oNewContext;
        }

    }
}
