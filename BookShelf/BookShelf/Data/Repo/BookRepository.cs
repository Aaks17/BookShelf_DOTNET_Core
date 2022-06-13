using BookShelf.Data.Interfaces;
using BookShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Data.Repo
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context)
            : base(context)
        {

        }

        public Book GetBook(int id)
        {
            return ApplicationContext.Books.Where(c => c.BookId == id).FirstOrDefault();
        }

        public void UpdateBook(Book Book)
        {
            ApplicationContext.Entry(Book).State = EntityState.Modified;
        }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }
    }
}
