using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategorys();
        Task<Category> GetCategory(int id);
        Task<Category> CreateCategory(Category Category);
        Task UpdateCategory(Category Category);
        Task DeleteCategory(int id);
    }
}
