using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public string Description { get; set; }
        public DateTime SellingDate { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Ingredient> Ingredients { get; set; }
    }
}
