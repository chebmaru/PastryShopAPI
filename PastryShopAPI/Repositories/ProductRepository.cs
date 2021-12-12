using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PastryShopAPI.Models;
using PastryShopAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly PastryShopContext _context;
        private readonly IOptions<Properties> _properties;

        public ProductRepository(PastryShopContext context,
                                 IOptions<Properties> properties)
        {
            _context = context;
            _properties = properties;

        }
        public async Task<Product> CreateProduct(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteProduct(int id)
        {
            var productToDelete = await _context.Products.FindAsync(id);
            var ingredientsToDelete = _context.Ingredient.Where(x =>
             x.ProductID == productToDelete.Id).FirstOrDefault();
            _context.Products.Remove(productToDelete);
            if(ingredientsToDelete != null)
               _context.Ingredient.Remove(ingredientsToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return (IEnumerable<Product>)await _context.Products
                .Where(x => x.SellingDate > DateTime.Now.AddDays(-_properties.Value.MaxDaysSelling)).Include(
                x => x.Category).Include(x => x.Ingredients).ToListAsync();
        }

        public Product GetProduct(int id)
        {
            return (Product) _context.Products
                .Include( x => x.Category).Include(x => x.Ingredients)
                .Where(x => x.Id == id && x.SellingDate > DateTime.Now.AddDays(-_properties.Value.MaxDaysSelling)).FirstOrDefaultAsync().Result;
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}
