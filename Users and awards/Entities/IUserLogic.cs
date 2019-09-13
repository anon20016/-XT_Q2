using System.Collections.Generic;

namespace Entities
{
    public interface IUserLogic
    {       
        bool AddUser(string name, string dayofbirth);
        bool RemoveUser(string name, string dayofbirth);

        User Find(int id);
        int Find(string name, string dayofbirth);

        void LoadData();
        void SaveData();
        ICollection<User> GetAll();
    }
}
