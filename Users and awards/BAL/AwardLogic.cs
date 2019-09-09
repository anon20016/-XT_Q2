using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using System.Threading.Tasks;

namespace BAL
{
    public class AwardLogic : IAwardLogic, IAssociate
    {
        public IStorable<Award> MemoryStorage = new AwardStorage();
        public IStorable<Association> AsStorage = new AssotiationStorage();

        public AwardLogic(){
            MemoryStorage.Load();
            AsStorage.Load();
        }

        public bool Associate(int fr, int sc)
        {
            return AsStorage.Add(new Association(fr, sc));            
        }

        public bool deAssociate(int fr, int sc)
        {
            return AsStorage.Remove(new Association(fr, sc));
        }

        public ICollection<Award> GetAll()
        {
            return MemoryStorage.GetAll();
        }

        public void LoadData()
        {
            MemoryStorage.Load();
        }

    }
}
