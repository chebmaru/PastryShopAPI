using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Repositories
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredient>> GetIngredients();
        Task<Ingredient> GetIngredient(int id);
        Task<Ingredient> CreateIngredient(Ingredient Ingredient);
        Task UpdateIngredient(Ingredient Ingredient);
        Task DeleteIngredient(int id);
    }
}
