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
            return MemoryStorage.Exists(new LoginData(login, GetHash(password)));
        }
        public bool Add(string login, string password)
        {
            return MemoryStorage.Add(new LoginData(login, GetHash(password)));
        }

        public bool Exist(string login)
        {
            return MemoryStorage.Exists(new LoginData(login, ""));
        }
            
        public bool Remove(string login)
        {
            return MemoryStorage.Remove(new LoginData(login, ""));
        }

        public bool Update(string login, string password)
        {
            return MemoryStorage.Update(0, new LoginData(login, password));
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
