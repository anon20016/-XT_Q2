using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL
{
    public class AwardStorage : IStorable<Award>
    {
        private List<Award> Awards { get; set; }
        private string path { get; set; }

        public AwardStorage(string p)
        {
            path = p;
            Awards = new List<Award>();
        }

        public bool Add(Award note)
        {
            if (FindAward(note.Name) == null)
            {
                Awards.Add(note);
                return true;
            }
            Award.count--;
            return false;            
        }
        public bool Add(string name, string discr)
        {
            if (FindAward(name) == null)
            {
                Awards.Add(new Award(++Award.count, name, discr));
                return true;
            }
            return false;
        }
  
        public bool Find(Award note)
        {
            return Awards.Contains(note);
        }
        public Award Find(int id)
        {
            return FindAward(id);
        }

        Award FindAward(string name)
        {
            var r = from item in Awards where (item.Name == name) select item;
            if (r.Count() > 0)
            {
                return r.First();
            }
            else
            {
                return null;
            }
        }
        Award FindAward(int id)
        {
            var r = from item in Awards where (item.Id == id) select item;
            if (r.Count() > 0)
            {
                return r.First();
            }
            else
            {
                throw new FormatException("Error");
            }
        }

        public void Load()
        {
            
            if (File.Exists(path))
            {
                int mxID = 0;
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t = line.Split('*');
                        if (t.Length == 3)
                        {
                            int temp = System.Convert.ToInt32(t[0]);
                            Awards.Add(new Award(temp, t[1], t[2]));
                            if (temp > mxID)
                            {
                                mxID = temp;
                            }
                        }
                    }
                }
                Award.count = mxID;
            }
        }

        public bool Remove(string name)
        {
            if (FindAward(name) != null)
            {
                Awards.Remove(FindAward(name));
                return true;
            }
            return false;
        }
        public bool Remove(int id)
        {
            if (FindAward(id) != null)
            {
                Awards.Remove(FindAward(id));
                return true;
            }
            return false;
        }
        public bool Remove(Award note)
        {
            if (note.Id == -1)
            {
                return Remove(note.Name);
            }
            else
            {
                return Remove(note.Id);
            }
        }

        public void Save()
        {
            using (StreamWriter sr = new StreamWriter(path))
            {
                foreach (var item in Awards)
                {
                    sr.WriteLine($"{item.Id}*{item.Name}*{item.Discription}");
                }
            }
        }

        public ICollection<Award> GetAll()
        {
            return Awards;
        }


    }
}
