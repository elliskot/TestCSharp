using System.Linq;

namespace TestCSharp.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Get();
    }
}
