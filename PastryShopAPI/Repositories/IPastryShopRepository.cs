using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Repositories
{
    public interface IPastryShopRepository
    {
        Task<IEnumerable<PastryShop>> GetPastryShops();
        Task<PastryShop> GetPastryShop(int id);
        Task<PastryShop> CreatePastryShop(PastryShop pastryShop);
        Task UpdatePastryShop(PastryShop pastryShop);
        Task DeletePastryShop(int id);
    }
}
