using BookShelf.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShelf.Data.Repo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationContext Context;
        internal DbSet<T> dbset;

        public Repository(ApplicationContext context)
        {
            this.Context = context;
            this.dbset = Context.Set<T>();

        }
        public void Add(T obj)
        {
            Context.Set<T>().Add(obj);
        }

        public void Delete(T obj)
        {
            Context.Set<T>().Remove(obj);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);

                }
            }
            return query.ToList();
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter, string? includeProperties = null)
        {
            IQueryable<T>? query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }
            return query.FirstOrDefault();
        }
    }
}
