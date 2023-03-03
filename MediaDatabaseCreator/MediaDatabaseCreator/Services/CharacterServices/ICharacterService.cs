using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Services.CharacterServices
{
    public interface ICharacterService : ICrudService<Character, int>
    {
        Task<IEnumerable<Movie>> GetMoviesAsync(int id);
    }
}
