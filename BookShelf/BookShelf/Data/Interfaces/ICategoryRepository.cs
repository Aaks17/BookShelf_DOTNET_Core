using BookShelf.Models;

namespace BookShelf.Data.Interfaces
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Category GetCategory(int id);
        void UpdateCategory(Category obj);
    }
}
