using DAL;
using Entities;
using System.Collections.Generic;

namespace BAL
{
    public class AwardLogic : IAwardLogic, IAssociate
    {
        public IStorable<Award> MemoryStorage = new AwardStorage();
        public IStorable<Association> AsStorage = new AssotiationStorage();

        public void AddAward(string name, string discription)
        {
            if (MemoryStorage.Add(new Award(++Award.count, name, discription)))
            {

            }
            else
            {

            }

        }
        public void RemoveAward(string name)
        {
            if (MemoryStorage.Remove(new Award(-1, name, "")))
            {

            }
            else
            {

            }
        }

        public bool Associate(int fr, int sc)
        {
            return AsStorage.Add(new Association(fr, sc));
        }
        public bool deAssociate(int fr, int sc)
        {
            return AsStorage.Remove(new Association(fr, sc));
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

        
    }
}
