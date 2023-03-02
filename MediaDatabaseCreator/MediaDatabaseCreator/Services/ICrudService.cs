namespace MediaDatabaseCreator.Services
{
    public interface ICrudService <T,ID>
    {
        ICollection<T> GetAll();
        T GetById(ID id);
        T Add(T obj);
        T Update(T obj);
        T Delete(ID obj);
    }
}
