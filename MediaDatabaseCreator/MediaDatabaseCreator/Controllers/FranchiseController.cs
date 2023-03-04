using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediaDatabaseCreator.Services.Franchises;
using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Controllers
{
    [Route("api/v1/franchises")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseService _franchiseService;
        public FranchiseController(IFranchiseService franchiseService)
        {
            _franchiseService = franchiseService;
        }

        // GET: api/v1/franchises 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return Ok(await _franchiseService.GetAllAsync());
        }
        
        // GET: api/v1/franchises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Franchise>> GetFranchise(int id)
        {
            var franchise = await _franchiseService.GetByIdAsync(id);

            if (franchise == null)
            {
                return NotFound();
            }

            return franchise;
        }

        // PUT: api/v1/franchises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, Franchise franchise)
        {
            if (id != franchise.FranchiseId)
            {
                return BadRequest();
            }

            await _franchiseService.UpdateAsync(franchise); // TODO:
                                                            // make it throw an error if the franchise does not exist,
                                                            // and if it is thrown: return NotFound()

            return NoContent();
        }

        // POST: api/v1/franchises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Franchise>> PostFranchise(Franchise franchise)
        {
            await _franchiseService.AddAsync(franchise);
            return CreatedAtAction("GetFranchise", new { id = franchise.FranchiseId }, franchise);
        }

        // DELETE: api/v1/franchises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id)
        {
            var franchise = await _franchiseService.DeleteAsync(id);
            if (franchise == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
