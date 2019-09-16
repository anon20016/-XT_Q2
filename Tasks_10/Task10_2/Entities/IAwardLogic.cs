using System.Collections.Generic;

namespace Entities
{
    public interface IAwardLogic
    {       
        bool AddAward(string name, string discription);
        bool RemoveAward(string s);

        Award Find(int id);
        int Find(string name);

        void LoadData();
        void SaveData();
        ICollection<Award> GetAll();
    }
}
