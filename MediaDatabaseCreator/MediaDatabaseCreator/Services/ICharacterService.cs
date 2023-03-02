using MediaDatabaseCreator.Model;

namespace MediaDatabaseCreator.Services
{
    public interface ICharacterService : ICrudService<Character, int>
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(int id);
    }
}
