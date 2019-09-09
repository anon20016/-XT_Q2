using System.Collections.Generic;

namespace Entities
{
    public interface IStorable<T>
    {
        bool Add(T note);
        bool Remove(T note);
        bool Remove(int id);
        bool Find(T note);
        T Find(int id);
        void Save();
        void Load();

        ICollection<T> GetAll();
    }
}
