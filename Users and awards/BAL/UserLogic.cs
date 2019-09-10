using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BAL
{
    public class UserLogic : IUserLogic
    {
        public IStorable<User> MemoryStorage = new UserStorage();

        public bool AddUser(string name, string dayofbirth)
        {
            Regex regex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
            if (regex.IsMatch(dayofbirth) && name.Length > 0)
            {
                return MemoryStorage.Add(new User(++User.count, name, dayofbirth));
            }
            else
            {
                throw new FormatException("Error in data format");
            }
        }
        
        public bool RemoveUser(string name, string dayofbirth)
        {
            Regex regex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
            if (regex.IsMatch(dayofbirth))
            {
                return !MemoryStorage.Remove(new User(-1, name, dayofbirth));                
            }
            else
            {
                throw new FormatException("Error in data format");
            }
        }

        public User Find(int id)
        {
            return MemoryStorage.Find(id);
        }
        public void SaveData()
        {
            MemoryStorage.Save();
        }
        public void LoadData()
        {
            MemoryStorage.Load();
        }

        public ICollection<User> GetAll()
        {
            return MemoryStorage.GetAll();
        }
    }
}
