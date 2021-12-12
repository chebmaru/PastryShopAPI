using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProducts();
        Product GetProduct(int id);
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
