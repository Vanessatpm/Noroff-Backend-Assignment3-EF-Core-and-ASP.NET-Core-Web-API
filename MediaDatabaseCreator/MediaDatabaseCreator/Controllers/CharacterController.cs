using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediaDatabaseCreator.Model.Entities;
using AutoMapper;
using MediaDatabaseCreator.Model.DTO;
using MediaDatabaseCreator.Services.CharacterServices;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.Mime;

namespace MediaDatabaseCreator.Controllers
{
    /// <summary>
    /// Controller for Characters
    /// contains generic CRUD operations
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        private readonly IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        // GET: api/Characters
        /// <summary>
        /// returns a list of all characters in database
        /// </summary>
        /// <returns>List Of Characters</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            return Ok(await _characterService.GetAllAsync());
        }

        // GET: api/Characters/5
        /// <summary>
        /// gets a single character and its relevant data from database
        /// </summary>
        /// <param name="id">Id of character</param>
        /// <returns>Character</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            var character = await _characterService.GetByIdAsync(id);

            if (character == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CharacterDTO>(character));
        }

        [HttpGet("{id}/movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesForCharacter(int id)
        {
            return Ok(await _characterService.GetMoviesAsync(id));
        }

        // PUT: api/Characters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, Character character)
        {
            if (id != character.CharacterId)
            {
                return BadRequest();
            }

            await _characterService.UpdateAsync(character);

            return NoContent();
        }

        // POST: api/Characters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
           await _characterService.AddAsync(character);

            return CreatedAtAction("GetCharacter", new { id = character.CharacterId }, character);
        }

    }
}
