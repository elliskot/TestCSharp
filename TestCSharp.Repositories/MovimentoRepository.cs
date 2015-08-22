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
    public class MovimentoRepository : ReadWriteRepository<Movimento, TestCSharpContext>, IMovimentoRepository
    {
        public MovimentoRepository(IDatabaseFactory<TestCSharpContext> databaseFactory)
            : base(databaseFactory)
        {
        }

        public override IQueryable<Movimento> GetAll()
        {
            IQueryable<Movimento> oQueryable = DataContext.Movimenti
                .Include(m => m.Articolo)
                .Include(m => m.Partenza)
                .Include(m => m.Destinazione)
                .Include(m => m.Causale);

            return oQueryable;
        }

        public override IQueryable<Movimento> GetAllSimpleList()
        {
            IQueryable<Movimento> oQueryable = DataContext.Movimenti;

            return oQueryable;
        }

        public override IQueryable<Movimento> GetEdit()
        {
            IQueryable<Movimento> oQueryable = DataContext.Movimenti
                .Include(m => m.Articolo);
            //.Include(m => m.Partenza)
            //.Include(m => m.Destinazione);

            oQueryable = this.ApplySecurityOnWrite(oQueryable);
            return oQueryable;
        }

        public override IQueryable<Movimento> Get()
        {
            IQueryable<Movimento> oQueryable = DataContext.Movimenti;

            return oQueryable;
        }

        protected override IQueryable<Movimento> ApplySecurityOnWrite(IQueryable<Movimento> query)
        {
            // Qui applico le regole per l'accesso al db

            return query;
        }

    }

    public interface IMovimentoRepository : IReadWriteRepository<Movimento>
    {
    }
}
