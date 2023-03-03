using MediaDatabaseCreator.Model;
using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Services
{
    public class MovieService : IMovieService
    {
        private readonly FilmDbContext _context;
        public MovieService(FilmDbContext context)
        {
            _context = context;
        }

        public Task<Movie> AddAsync(Movie obj)
        {
            throw new NotImplementedException();
        }

        public Task<Movie?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Character>?> GetAllCharactersAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateAsync(Movie obj)
        {
            throw new NotImplementedException();
        }
    }
}
