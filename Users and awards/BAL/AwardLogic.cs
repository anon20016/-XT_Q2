using DAL;
using Entities;
using System.Collections.Generic;

namespace BAL
{
    public class AwardLogic : IAwardAssotiateLogic
    {
        public IStorable<Award> MemoryStorage = new AwardStorage(@"Awards.txt");
        public IStorable<Association> AsStorage = new AssotiationStorage(@"assotiations.txt");

        public bool AddAward(string name, string discription)
        {
            if (name.Length > 0)
            {
                return (MemoryStorage.Add(new Award(++Award.count, name, discription)));
            }
            return false;
        }
        public bool RemoveAward(string name)
        {
            return (MemoryStorage.Remove(new Award(-1, name, "")));
        }

        public bool Associate(int fr, int sc)
        {
            if (MemoryStorage.Find(sc) != null)
            {
                return AsStorage.Add(new Association(fr, sc));
            }
            else
            {
                throw new KeyNotFoundException("No such Award");
            }
        }
        public bool deAssociate(int fr, int sc)
        {
            if (MemoryStorage.Find(sc) != null)
            {
                return AsStorage.Remove(new Association(fr, sc));
            }
            else
            {
                throw new KeyNotFoundException("No such Award");
            }
        }

        public Award Find(int id)
        {
            return MemoryStorage.Find(id);
        }

        public ICollection<Award> GetAll()
        {
            return MemoryStorage.GetAll();
        }

        public ICollection<Association> GetAllAssotiations()
        {
            return AsStorage.GetAll();
        }

        public void LoadData()
        {
            MemoryStorage.Load();
            AsStorage.Load();
        }
        public void SaveData()
        {
            MemoryStorage.Save();
            AsStorage.Save();
        }
    }
}
