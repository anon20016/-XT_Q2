using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;

namespace BAL
{
    public class RoleLogic
    {
        private IStorable<Role> MemoryStorage;
        private string path = @"C:\Temp\Users.txt";


        public RoleLogic(string p)
        {
            path = p;
            MemoryStorage = new RolesStorage(path);
        }

        public void AddUser(string name)
        {
            
        }

        public Dictionary<string, List<string>> GetU()
        {
            Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();

            var a = MemoryStorage.GetAll();
            foreach(var item in a)
            {
                foreach(var u in item.Users)
                {
                    if (!temp.ContainsKey(u))
                    {
                        temp.Add(u, new List<string>());
                    }
                    temp[u].Add(item.Name);
                }
                
            }
            return temp;
        }
        public Dictionary<string, List<string>> GetR()
        {
            Dictionary<string, List<string>> temp = new Dictionary<string, List<string>>();
            var a = MemoryStorage.GetAll();
            foreach (var item in a)
            {
                temp.Add(item.Name, item.Users);
            }
            return temp;
        }

        public void SaveData()
        {
            MemoryStorage.Save();
        }
        public void LoadData()
        {
            MemoryStorage.Load();
        }


    }
}
