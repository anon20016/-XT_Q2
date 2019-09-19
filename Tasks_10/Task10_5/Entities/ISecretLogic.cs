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
        bool Add(string login, string password);
        bool Remove(string login);
        bool Update(string login, string password);

        void LoadData();
        void SaveData();
    }
}
