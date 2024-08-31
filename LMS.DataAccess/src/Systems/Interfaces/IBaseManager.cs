namespace LMS.DataAccess.Systems.Interfaces;

public interface IBaseManager<T>
{
    bool Add(T item);
    bool Update(T item);
    bool Remove(T item);
    List<T> GetAll();
}
