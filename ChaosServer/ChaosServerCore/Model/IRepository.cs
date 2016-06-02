using System.Collections.Generic;

namespace ChaosServerCore.Model
{
    public interface IRepository<T, U> where T : IIndexable
    {
        IEnumerable<T> GetAll();

        T GetItem(U key);

        bool AddItem(T item);

        bool UpdateItem(U key, T item);

        bool DeleteItem(U item);
    }
}
