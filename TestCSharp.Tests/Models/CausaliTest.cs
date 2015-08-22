using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestCSharp.DataAccess;
using TestCSharp.Models;
using TestCSharp.Models.Entities;
using TestCSharp.Repositories;

namespace TestCSharp.Tests.Models
{
    [TestClass]
    public class CausaliTest : ReadWriteRepository<Causale, TestCSharpContext>, ICausaleRepository
    {
        private List<Causale> _db = new List<Causale>();

        protected abstract IQueryable<T> ApplySecurityOnWrite(IQueryable<T> query);
        public abstract IQueryable<T> GetEdit();

        [TestMethod]
        public void Add(Causale oCausale)
        {
            _db.Add(oCausale);
        }
        public virtual void Add(T entity)
        {
            this.DbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            this.DbSet.Attach(entity);
            this.DataContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            this.DbSet.Remove(entity);
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = this.DbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                this.DbSet.Remove(obj);
        }
                
        //[TestMethod]
        //public void Update(Causale oCausale)
        //{
        //    _db.FirstOrDefault(d => d.ID == oCausale.ID) = oCausale;
        //}
        
        //[TestMethod]
        //public void Delete(Causale oCausale)
        //{
        //    _db.Remove(oCausale);
        //}
        
        //[TestMethod]
        //public void Delete()
        //{
        //}
        
        //[TestMethod]
        //public IQueryable<Causale> GetEdit()
        //{
        //}

        //void Add(T entity);
        //void Update(T entity);
        //void Delete(T entity);
        //void Delete(Expression<Func<T, bool>> where);

        //IQueryable<T> GetEdit();

        
    }
}
