using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MediaDatabaseCreator.Model.Entities;
using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Services;

namespace MediaDatabaseCreator.Controllers
{
    [Route("api/v1/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/v1/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return Ok(await _movieService.GetAllAsync());
        }

        // GET: api/v1/movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _movieService.GetByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // PUT: api/v1/movies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }
            await _movieService.UpdateAsync(movie);// TODO:
                                                   // make it throw an error if the franchise does not exist,
                                                   // and if it is thrown:
                                                   // return NotFound()
            return NoContent();
        }

        // POST: api/v1/movies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            await _movieService.AddAsync(movie);
            return CreatedAtAction("GetMovie", new { id = movie.MovieId }, movie);
        }

        // DELETE: api/v1/movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _movieService.DeleteAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}
