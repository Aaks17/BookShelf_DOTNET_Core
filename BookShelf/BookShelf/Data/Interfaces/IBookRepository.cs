using BookShelf.Models;

namespace BookShelf.Data.Interfaces
{
    public interface IBookRepository : IRepository<Book>
    {
        Book GetBook(int id);
        void UpdateBook(Book obj);
    }
}
