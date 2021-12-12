using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PastryShopAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct([FromBody] Product Product)
        {
            var newProduct = await _productRepository.CreateProduct(Product);
            return CreatedAtAction(nameof(GetProducts), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut]
        public async Task<ActionResult> PutProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            await _productRepository.UpdateProduct(product);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var productToDelete =  _productRepository.GetProduct(id);
            if (productToDelete == null)
                return NotFound();

            await _productRepository.DeleteProduct(productToDelete.Id);
            return Ok();
        }
    }

}
