using Microsoft.EntityFrameworkCore;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly PastryShopContext _context;

        public IngredientRepository(PastryShopContext context)
        {
            _context = context;
        }
        public async Task<Ingredient> CreateIngredient(Ingredient ingredient)
        {
            _context.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task DeleteIngredient(int id)
        {
            var IngredientToDelete = await _context.Ingredient.FindAsync(id);
            _context.Ingredient.Remove(IngredientToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            return (IEnumerable<Ingredient>)await _context.Ingredient.ToListAsync();
        }

        public async Task<Ingredient> GetIngredient(int id)
        {
            return (Ingredient)await _context.Ingredient.FindAsync(id);
        }

        public async Task UpdateIngredient(Ingredient ingredient)
        {
            _context.Entry(ingredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}
