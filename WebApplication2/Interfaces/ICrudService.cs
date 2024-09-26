namespace WebApplication2.Interfaces
{
    public interface ICrudService<T>
    {
        List<T> GetAll();
        T GetById(long id);
        T Add(T entity);
        bool Update(long id, T entity);
        bool Delete(long id);
    }
}
