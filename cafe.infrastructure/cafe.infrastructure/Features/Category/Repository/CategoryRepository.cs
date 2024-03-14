using cafe.Domain.Category;
using cafe.Domain.Category.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Category.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CafeDbContext _context;

        public CategoryRepository(CafeDbContext context)
        {
            _context = context;
        }

        public CategoryEntity CreateCategory(CategoryEntity category)
        {
            _context.Catgeories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(CategoryEntity category)
        {
            _context.Catgeories.Remove(category);
            _context.SaveChanges();
        }

        public ICollection<CategoryEntity> GetCategories()
        {
            return _context.Catgeories.ToList();
        }

        public CategoryEntity UpdateCategory(CategoryEntity category)
        {
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }
    }
}