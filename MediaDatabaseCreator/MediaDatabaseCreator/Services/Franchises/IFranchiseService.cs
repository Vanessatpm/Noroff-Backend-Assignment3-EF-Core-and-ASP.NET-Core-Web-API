using MediaDatabaseCreator.Model;

namespace MediaDatabaseCreator.Services.Franchises
{
    public interface IFranchiseService : ICrudService<Franchise, int>
    {
        Task<IEnumerable<Franchise>?> GetAllMovies(int id);
    }
}
