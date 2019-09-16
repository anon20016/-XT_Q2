using DAL;
using Entities;
using System.Collections.Generic;

namespace BAL
{
    public class AwardLogic : IAwardAssotiateLogic
    {
        private string path_awards, path_ass;

        public IStorable<Award> MemoryStorage;
        public IStorable<Association> AsStorage;

        public AwardLogic(string p1, string p2)
        {
            path_awards = p1;
            path_ass = p2;

            MemoryStorage = new AwardStorage(path_awards);
            AsStorage = new AssotiationStorage(path_ass);
        }

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
        public int Find(string name)
        {
            return MemoryStorage.Find(new Award(-1, name, ""));
        }

        public ICollection<Award> GetAll()
        {
            return MemoryStorage.GetAll();
        }

        public ICollection<Association> GetAllAssotiations()
        {
            return AsStorage.GetAll();
        }

        public void RemoveFirstId(int x)
        {
            AsStorage.Remove(new Association(x, -1));
        }
        public void RemoveSecondId(int x)
        {
            AsStorage.Remove(new Association(-1, x));
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
