using System.Collections.Generic;

namespace Entities
{
    public interface IAwardLogic
    {       
        bool AddAward(string name, string discription);
        bool RemoveAward(string name);
        Award Find(int id);

        void LoadData();
        void SaveData();
        ICollection<Award> GetAll();
    }
}
