using Microsoft.EntityFrameworkCore;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Repositories
{
    public class PastryShopRepository : IPastryShopRepository
    {
        private readonly PastryShopContext _context;

        public PastryShopRepository(PastryShopContext context)
        {
            _context = context;
        }
        public async Task<PastryShop> CreatePastryShop(PastryShop pastryShop)
        {
            _context.Add(pastryShop);
            await _context.SaveChangesAsync();
            return pastryShop;
        }

        public async Task DeletePastryShop(int id)
        {
            var PastryShopToDelete = await _context.PastryShop.FindAsync(id);
            _context.PastryShop.Remove(PastryShopToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<PastryShop>> GetPastryShops()
        {
            return (IEnumerable<PastryShop>)await _context.PastryShop.ToListAsync();
        }

        public async Task<PastryShop> GetPastryShop(int id)
        {
            return (PastryShop)await _context.PastryShop.FindAsync(id);
        }

        public async Task UpdatePastryShop(PastryShop PastryShop)
        {
            _context.Entry(PastryShop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}
