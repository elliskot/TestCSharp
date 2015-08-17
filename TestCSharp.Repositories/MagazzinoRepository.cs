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
    public class MagazzinoRepository : ReadWriteRepository<Magazzino, TestCSharpContext>, IMagazzinoRepository
    {
        public MagazzinoRepository(IDatabaseFactory<TestCSharpContext> databaseFactory)
            : base(databaseFactory)
        {
        }

        public IQueryable<Magazzino> GetAll()
        {
            IQueryable<Magazzino> oQueryable = DataContext.Magazzini
                .Include(m => m.Movimenti);

            return oQueryable;
        }

        public IQueryable<Magazzino> GetAllSimpleList()
        {
            IQueryable<Magazzino> oQueryable = DataContext.Magazzini;

            return oQueryable;
        }

        public override IQueryable<Magazzino> GetEdit()
        {
            IQueryable<Magazzino> oQueryable = DataContext.Magazzini;

            oQueryable = this.ApplySecurityOnWrite(oQueryable);
            return oQueryable;
        }


        public override IQueryable<Magazzino> Get()
        {
            IQueryable<Magazzino> oQueryable = DataContext.Magazzini;

            return oQueryable;
        }

        protected override IQueryable<Magazzino> ApplySecurityOnWrite(IQueryable<Magazzino> query)
        {
            // Qui applico le regole per l'accesso al db

            return query;
        }

    }

    public interface IMagazzinoRepository : IReadWriteRepository<Magazzino>
    {
    }
}
