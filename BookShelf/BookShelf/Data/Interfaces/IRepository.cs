using BookShelf.Models;
using System.Linq.Expressions;

namespace BookShelf.Data.Interfaces
{
    public interface IRepository<T>where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null);
        T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null);
        void Add(T obj);
        void Delete(T obj);        
    }
}
