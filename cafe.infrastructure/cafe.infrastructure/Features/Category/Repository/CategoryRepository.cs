using cafe.Common;
using cafe.Domain.Category;
using cafe.Domain.Category.Repository;
using Microsoft.EntityFrameworkCore;

namespace cafe.infrastructure.Features.Category.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CafeDbContext _context;

        private readonly LanguageService _localization;

        public CategoryRepository(CafeDbContext context, LanguageService localization)
        {
            _context = context;
            _localization = localization;
        }

        public async Task<CategoryEntity> Create(CategoryEntity category)
        {
            _context.Catgeories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task Delete(CategoryEntity category)
        {
            _context.Catgeories.Remove(category);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryEntity>> GetAllRecords()
        {
            return await _context.Catgeories.ToListAsync();
        }

        public async Task<CategoryEntity> Update(CategoryEntity category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return category;
        }
    }
}