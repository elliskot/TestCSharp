using System.Linq;

namespace TestCSharp.DataAccess.Interfaces
{
    public interface IReadOnlyRepository<T>
        : IRepository<T>
        where T : class
    {

        IQueryable<T> Get();

    }
}
