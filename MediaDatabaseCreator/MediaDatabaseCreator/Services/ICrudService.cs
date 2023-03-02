﻿namespace MediaDatabaseCreator.Services
{
    public interface ICrudService <T,ID>
    {
        Task<ICollection<T>> GetAllAsync();
        Task<T> GetByIdAsync(ID id);
        Task<T> AddAsync(T obj);
        Task<T> UpdateAsync(T obj);
        void Delete(ID obj);
    }
}
