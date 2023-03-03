namespace MediaDatabaseCreator.Services
{
    public interface ICrudService <T,ID>
    {
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<T?> GetByIdAsync(ID id); 
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        Task<T?> DeleteAsync(ID id);
    }
}
