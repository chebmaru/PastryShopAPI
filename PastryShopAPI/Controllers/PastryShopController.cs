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

    public class PastryShopController : ControllerBase
    {
        private readonly IPastryShopRepository _PastryShopRepository;

        public PastryShopController(IPastryShopRepository PastryShopRepository)
        {
            _PastryShopRepository = PastryShopRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<PastryShop>> GetPastryShops()
        {
            return await _PastryShopRepository.GetPastryShops();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PastryShop>> GetPastryShop(int id)
        {
            return await _PastryShopRepository.GetPastryShop(id);
        }

        [HttpPost]
        public async Task<ActionResult<PastryShop>> PostPastryShops([FromBody] PastryShop PastryShop)
        {
            var newPastryShop = await _PastryShopRepository.CreatePastryShop(PastryShop);
            return CreatedAtAction(nameof(GetPastryShops), new { id = newPastryShop.Id }, newPastryShop);
        }

        [HttpPut]
        public async Task<ActionResult> PutPastryShops(int id, [FromBody] PastryShop PastryShop)
        {
            if (id != PastryShop.Id)
            {
                return BadRequest();
            }

            await _PastryShopRepository.UpdatePastryShop(PastryShop);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var PastryShopToDelete = await _PastryShopRepository.GetPastryShop(id);
            if (PastryShopToDelete == null)
                return NotFound();

            await _PastryShopRepository.DeletePastryShop(PastryShopToDelete.Id);
            return NoContent();
        }
    }

}
