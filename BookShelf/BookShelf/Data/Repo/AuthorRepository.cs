using BookShelf.Data;
using BookShelf.Data.Interfaces;
using BookShelf.Data.Repo;
using BookShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Data.Repo
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext context)
            : base(context)
        {

        }

        public Author GetAuthor(int id)
        {
            return ApplicationContext.Authors.Where(c => c.AuthorId == id).FirstOrDefault();
        }

        public void UpdateAuthor(Author Author)
        {
            ApplicationContext.Entry(Author).State = EntityState.Modified;
        }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }
    }
}
