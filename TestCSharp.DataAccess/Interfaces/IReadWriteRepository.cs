using System;
using System.Linq;
using System.Linq.Expressions;

namespace TestCSharp.DataAccess.Interfaces
{
    public interface IReadWriteRepository<T>
        : IRepository<T>
        where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);

        IQueryable<T> GetAll();
        IQueryable<T> GetEdit();
    }
}
