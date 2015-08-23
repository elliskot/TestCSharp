using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestCSharp.DataAccess;
using TestCSharp.Models;
using TestCSharp.Repositories;

namespace TestCSharp.Tests.Models
{
    class InMemoryCausaleRepository : ICausaleRepository
    {
        private List<Causale> _db = new List<Causale>();
        
        public void Add(Causale oCausale)
        {
            _db.Add(oCausale);
        }

        public void Update(Causale oCausale)
        {
            _db.Remove(oCausale);
            _db.Add(oCausale);
        }

        public void Delete(Causale oCausale)
        {
            _db.Remove(oCausale);
        }

        public void Delete(Expression<Func<Causale, bool>> where)
        {
            IEnumerable<Causale> objects = _db.AsQueryable<Causale>().Where<Causale>(where).AsEnumerable();
            foreach (Causale oCausale in objects)
                _db.Remove(oCausale);
        }

        public IQueryable<Causale> GetAll()
        {
            return _db.AsQueryable<Causale>();
        }

        public IQueryable<Causale> GetAllSimpleList()
        {
            return _db.AsQueryable<Causale>();
        }

        public IQueryable<Causale> GetEdit()
        {
            return _db.AsQueryable<Causale>();
        }

        public IQueryable<Causale> Get()
        {
            return _db.AsQueryable<Causale>();
        }
    }
}
