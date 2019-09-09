using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IStorable<T>
    {
        bool Add(T note);
        bool Remove(T note);
        bool Find(T note);
        void Save();
        void Load();

        ICollection<T> GetAll();
    }
}
