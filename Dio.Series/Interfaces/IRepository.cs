using System.Collections.Generic;

namespace Dio.Series.Interfaces
{
    public interface IRepository<T>
    {
        List<T> list();
        T GetById(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(int id, T entity);
        int NextId();
    }
}