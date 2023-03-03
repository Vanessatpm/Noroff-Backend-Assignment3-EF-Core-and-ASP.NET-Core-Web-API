using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Services
{
    public interface IMovieService : ICrudService<Movie, int>
    {
        Task<IEnumerable<Character>?> GetAllCharactersAsync(int id);
    }
}
