using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Services
{
    public interface ICharacterService : ICrudService<Character, int>
    {
        Task<IEnumerable<MovieDTO>> GetMoviesAsync(int id);
    }
}
