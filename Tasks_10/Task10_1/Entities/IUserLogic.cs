using System.Collections.Generic;

namespace Entities
{
    public interface IUserLogic
    {       
        bool AddUser(string name, string dayofbirth);
        bool RemoveUser(string name, string dayofbirth);
        bool UpdateUser(int id, User user);
        User Find(int id);
        int Find(string name, string dayofbirth);

        void LoadData();
        void SaveData();
        ICollection<User> GetAll();
    }
}
