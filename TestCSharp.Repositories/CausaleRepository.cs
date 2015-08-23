using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCSharp.Models;
using TestCSharp.Models.Entities;
using TestCSharp.DataAccess;
using TestCSharp.DataAccess.Interfaces;

namespace TestCSharp.Repositories
{
    public class CausaleRepository : ReadWriteRepository<Causale, TestCSharpContext>, ICausaleRepository
    {
        public CausaleRepository(IDatabaseFactory<TestCSharpContext> databaseFactory)
            : base(databaseFactory)
        {
        }

        public override IQueryable<Causale> GetAll()
        {
            IQueryable<Causale> oQueryable = DataContext.Causali
                .Include(m => m.Movimenti);

            return oQueryable;
        }

        public override IQueryable<Causale> GetAllSimpleList()
        {
            IQueryable<Causale> oQueryable = DataContext.Causali;

            return oQueryable;
        }

        public override IQueryable<Causale> GetEdit()
        {
            IQueryable<Causale> oQueryable = DataContext.Causali;

            oQueryable = this.ApplySecurityOnWrite(oQueryable);
            return oQueryable;
        }

        public override IQueryable<Causale> Get()
        {
            IQueryable<Causale> oQueryable = DataContext.Causali;

            return oQueryable;
        }

        protected override IQueryable<Causale> ApplySecurityOnWrite(IQueryable<Causale> query)
        {
            // Qui applico le regole per l'accesso al db

            return query;
        }

    }

    public interface ICausaleRepository : IReadWriteRepository<Causale>
    {
    }
}
