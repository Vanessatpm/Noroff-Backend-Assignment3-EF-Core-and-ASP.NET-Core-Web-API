using MediaDatabaseCreator.Model.Entities;

namespace MediaDatabaseCreator.Services.Franchises
{
    public interface IFranchiseService : ICrudService<Franchise, int>
    {
        Task<IEnumerable<Franchise>?> GetAllMoviesAsync(int id);
        Task<IEnumerable<Character>?> GetAllCharactersAsync(int id);
        Task<Movie> UpdateMovieAsync(int id);

    }
}
