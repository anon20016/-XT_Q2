using System.Collections.Generic;

namespace Entities
{
    public interface IStorable<T>
    {
        bool Add(T note);
        bool Remove(T note);

        /// <summary>
        /// Removes note by id
        /// </summary>
        bool Remove(int id);
                     
        /// <summary>
        /// Checks if such note exists
        /// </summary>       
        bool Exists(T note);

        /// <summary>
        /// Finding note by id, returns null if no such Id
        /// </summary>       
        T Find(int id);

        /// <summary>
        /// Finding Id by T information
        /// </summary>        
        int Find(T note);

        bool Update(int id, T note);

        // Saving and Loading Information
        void Save();
        void Load();
        //
        ICollection<T> GetAll();
    }
}
