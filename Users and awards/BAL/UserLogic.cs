using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace BAL
{
    public class UserLogic
    {
        public IStorable<User> MemoryStorage = new UserStorage();

        public void AddUser(string name, string dayofbirth)
        {
            Regex regex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
            if (regex.IsMatch(dayofbirth))
            {
                if (!MemoryStorage.Find(new User(0, name, dayofbirth)))
                {
                    MemoryStorage.Add(new User(name, dayofbirth));
                }
                else
                {
                    throw new FormatException("This user already exists");
                }
            }
            else
            {
                throw new FormatException("Error in data format");
            }
        }
        public void AddUser(User note)
        {
            MemoryStorage.Add(note);
        }
        public void RemoveUser(User note)
        {
            MemoryStorage.Remove(note);
        }
        public void RemoveUser(string name, string dayofbirth)
        {
            Regex regex = new Regex(@"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
            if (regex.IsMatch(dayofbirth))
            {
                if (!MemoryStorage.Remove(new User(-1, name, dayofbirth)))
                {
                    throw new FormatException("No user");
                }
            }
            else
            {
                throw new FormatException("Error in data format");
            }
        }
        public void SaveData()
        {
            MemoryStorage.Save();
        }
        public void LoadData()
        {
            MemoryStorage.Load();
        }

        public ICollection<User> GetAllUsers()
        {
            return MemoryStorage.GetAll();
        }
    }
}
