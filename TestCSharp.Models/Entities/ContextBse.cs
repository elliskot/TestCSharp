using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCSharp.Models.Entities
{
    public class ContextBase : DbContext
    {
        public ContextBase() : this("TestCSharp.DataAccess.Context")
        {
        }

        public ContextBase(string name) : base(name)
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }

        public void Commit()
        {
            try
            {
                base.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}", validationErrors.Entry.Entity.GetType().FullName,
                                      validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }

    }
}
