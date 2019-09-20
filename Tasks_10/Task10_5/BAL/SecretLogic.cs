using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;

namespace BAL
{
    public  class SecretLogic : ISecretLogic
    {
        private IStorable<LoginData> MemoryStorage;
        private string path = @"C:\Temp\Users.txt";

        private string GetHash(string s)
        {
            string res = "";
            foreach(var i in s)
            {
                res += i;
            }
            return res;
        }

        public SecretLogic(string p)
        {
            path = p;
            MemoryStorage = new SecretStorage(path);
        }

        public bool Can(string login, string password)
        {
            return MemoryStorage.Exists(new LoginData(-1, login, GetHash(password)));
        }

        
        public bool Add(int id, string login, string password)
        {
            return MemoryStorage.Add(new LoginData(id, login, GetHash(password)));
        }

        public int GetIdByLogin(string login)
        {
            var t = MemoryStorage.Find(new LoginData(-1, login, ""));
            if (t != -1)
            {
                return t;
            }
            throw new ArgumentException("No such login");
        }

        public bool Exist(string login)
        {
            return MemoryStorage.Exists(new LoginData(-2, login, ""));
        }
            
        public bool Remove(string login)
        {
            return MemoryStorage.Remove(new LoginData(-1, login, ""));
        }
        public bool Remove(int id)
        {
            return MemoryStorage.Remove(id);
        }

        public bool Update(string login, string password)
        {
            throw new NotImplementedException();
        }

        public string[] GetAllUsers()
        {
            List<string> res = new List<string>();
            foreach(var item in MemoryStorage.GetAll())
            {
                res.Add(item.Login);
            }
            return res.ToArray();
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
