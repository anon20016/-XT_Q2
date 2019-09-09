using Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    class AwardStorage : IStorable<Award>
    {
        private List<Award> Awards { get; set; }

        public AwardStorage()
        {
            Awards = new List<Award>();
        }

        public bool Add(Award note)
        {
            Awards.Add(note);
            return true;
        }

        public bool Add(string name, string discr)
        {
            Awards.Add(new Award(0, name, discr));
            return true;
        }

        public bool Find(Award note)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Award> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(Award note)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}
