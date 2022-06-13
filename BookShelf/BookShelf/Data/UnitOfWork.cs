using BookShelf.Data.Interfaces;
using BookShelf.Data.Repo;
using BookShelf.Models;

namespace BookShelf.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _applicationContext;

        public UnitOfWork(ApplicationContext _applicationContext)
        {
            this._applicationContext = _applicationContext;
        }
        public ICategoryRepository Categories => new CategoryRepository(_applicationContext);
        public IAuthorRepository Authors => new AuthorRepository(_applicationContext);
        public IBookRepository Books => new BookRepository(_applicationContext);

        public void Dispose()
        {
            _applicationContext.Dispose();
        }

        public bool Save()
        {
            return _applicationContext.SaveChanges() > 0;
        }
    }
}
