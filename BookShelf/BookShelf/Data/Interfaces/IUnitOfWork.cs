using BookShelf.Models;

namespace BookShelf.Data.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        ICategoryRepository Categories { get; }
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }

        bool Save();
    }
}
