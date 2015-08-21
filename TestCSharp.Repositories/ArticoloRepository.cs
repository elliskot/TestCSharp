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
    public class ArticoloRepository : ReadWriteRepository<Articolo, TestCSharpContext>, IArticoloRepository
    {
        public ArticoloRepository(IDatabaseFactory<TestCSharpContext> databaseFactory)
            : base(databaseFactory)
        {
        }

        public override IQueryable<Articolo> GetAll()
        {
            IQueryable<Articolo> oQueryable = DataContext.Articoli
                .Include(m => m.Movimenti);

            return oQueryable;
        }

        public IQueryable<Articolo> GetAllSimpleList()
        {
            IQueryable<Articolo> oQueryable = DataContext.Articoli;

            return oQueryable;
        }

        public override IQueryable<Articolo> GetEdit()
        {
            IQueryable<Articolo> oQueryable = DataContext.Articoli;

            oQueryable = this.ApplySecurityOnWrite(oQueryable);
            return oQueryable;
        }

        public override IQueryable<Articolo> Get()
        {
            IQueryable<Articolo> oQueryable = DataContext.Articoli;

            return oQueryable;
        }

        protected override IQueryable<Articolo> ApplySecurityOnWrite(IQueryable<Articolo> query)
        {
            // Qui applico le regole per l'accesso al db

            return query;
        }

    }

    public interface IArticoloRepository : IReadWriteRepository<Articolo>
    {
    }
}
