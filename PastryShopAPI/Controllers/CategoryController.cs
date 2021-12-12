using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PastryShopAPI.Models;
using PastryShopAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PastryShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ICategoryRepository CategoryRepository)
        {
            _CategoryRepository = CategoryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _CategoryRepository.GetCategorys();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _CategoryRepository.GetCategory(id);
        }

        [HttpPost]
        public async Task<ActionResult<Category>> PostCategories([FromBody] Category Category)
        {
            var newCategory = await _CategoryRepository.CreateCategory(Category);
            return CreatedAtAction(nameof(GetCategories), new { id = newCategory.Id }, newCategory);
        }

        [HttpPut]
        public async Task<ActionResult> PutCategorys(int id, [FromBody] Category Category)
        {
            if (id != Category.Id)
            {
                return BadRequest();
            }

            await _CategoryRepository.UpdateCategory(Category);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var CategoryToDelete = await _CategoryRepository.GetCategory(id);
            if (CategoryToDelete == null)
                return NotFound();

            await _CategoryRepository.DeleteCategory(CategoryToDelete.Id);
            return NoContent();
        }
    }

}
