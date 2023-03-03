namespace MediaDatabaseCreator.Services
{
    public interface ICrudService <T,ID>
    {
        Task<ICollection<T>> GetAllAsync(); // TODO: replace ICollection with IEnumerable
        Task<T> GetByIdAsync(ID id); // TODO: Make nullable
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        void Delete(ID obj); // TODO: Replace void with Task<T?>,
                             // Rename to DeleteAsync,
                             // and rename obj to id.
    }
}
