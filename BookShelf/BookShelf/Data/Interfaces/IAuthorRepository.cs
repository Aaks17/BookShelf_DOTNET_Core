using BookShelf.Models;

namespace BookShelf.Data.Interfaces
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Author GetAuthor(int id);
        void UpdateAuthor(Author obj);
    }
}
