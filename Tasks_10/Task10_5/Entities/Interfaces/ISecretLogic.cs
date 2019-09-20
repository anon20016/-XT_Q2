using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace Entities
{
    public interface ISecretLogic
    {
        bool Can(string login, string password);

        bool Exist(string login);
        bool Add(int id, string login, string password);
        bool Remove(string login);
        bool Remove(int id);
        bool Update(string login, string password);

        string[] GetAllUsers();
        int GetIdByLogin(string login);

        void LoadData();
        void SaveData();
    }
}
