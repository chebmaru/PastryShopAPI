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

    public class IngredientController : ControllerBase
    {
        private readonly IIngredientRepository _IngredientRepository;

        public IngredientController(IIngredientRepository IngredientRepository)
        {
            _IngredientRepository = IngredientRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Ingredient>> GetIngredients()
        {
            return await _IngredientRepository.GetIngredients();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(int id)
        {
            return await _IngredientRepository.GetIngredient(id);
        }

        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredients([FromBody] Ingredient Ingredient)
        {
            var newIngredient = await _IngredientRepository.CreateIngredient(Ingredient);
            return CreatedAtAction(nameof(GetIngredients), new { id = newIngredient.Id }, newIngredient);
        }

        [HttpPut]
        public async Task<ActionResult> PutIngredients(int id, [FromBody] Ingredient Ingredient)
        {
            if (id != Ingredient.Id)
            {
                return BadRequest();
            }

            await _IngredientRepository.UpdateIngredient(Ingredient);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIngredient(int id)
        {
            var IngredientToDelete = await _IngredientRepository.GetIngredient(id);
            if (IngredientToDelete == null)
                return NotFound();

            await _IngredientRepository.DeleteIngredient(IngredientToDelete.Id);
            return NoContent();
        }
    }

}
