using Microsoft.EntityFrameworkCore;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PastryShopContext _context;

        public CategoryRepository(PastryShopContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            _context.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task DeleteCategory(int id)
        {
            var CategoryToDelete = await _context.Category.FindAsync(id);
            _context.Category.Remove(CategoryToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategorys()
        {
            return (IEnumerable<Category>)await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            return await _context.Category.FindAsync(id);
        }

        public async Task UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}
