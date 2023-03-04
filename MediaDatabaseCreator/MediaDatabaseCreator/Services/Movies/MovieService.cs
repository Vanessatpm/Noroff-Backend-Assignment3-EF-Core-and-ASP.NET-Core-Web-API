using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MediaDatabaseCreator.Services
{
    public class MovieService : IMovieService
    {
        private readonly FilmDbContext _context;
        public MovieService(FilmDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Character>?> GetAllCharactersAsync(int id)
        {
            //var movie = await GetByIdAsync(id);
            //if (movie == null)
            //{
            //    return null;
            //}
            // TODO: fetch characters. //return await movie.Characters.ToListAsync();
            throw new NotImplementedException();
        }

        public async Task<Movie> AddAsync(Movie obj)
        {
            await _context.Movies.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Movie> UpdateAsync(Movie obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            // TODO:
            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!FranchiseExists(id))
            //    {
            //        return null; 
            // TODO: make Franchise in return value nullable

            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return obj;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var movie = await GetByIdAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);

            }
            return movie;
        }

        //private bool MovieExists(int id)
        //{
        //    return _context.Movies.Any(e => e.MovieId == id);
        //}
    }
}
