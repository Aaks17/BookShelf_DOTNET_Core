using BookShelf.Data.Interfaces;
using BookShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShelf.Data.Repo
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationContext context)
            :base(context)
        {
                
        }

        public Category GetCategory(int id)
        {
            return ApplicationContext.Categories.Where(c => c.CategoryId == id).FirstOrDefault();
        }

        public void UpdateCategory(Category category)
        {
            ApplicationContext.Entry(category).State = EntityState.Modified;
        }

        public ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext ; }
        }

    }
}
