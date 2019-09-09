using Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace DAL
{
    public class AwardStorage : IStorable<Award>
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
            Awards.Add(new Award(++Award.count, name, discr));
            return true;
        }

        public bool Find(Award note)
        {
            return Awards.Contains(note);
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
                throw new FormatException("Error");
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
            if (File.Exists(@"awards.txt"))
            {
                int mxID = 0;
                using (StreamReader sr = new StreamReader(@"awards.txt", System.Text.Encoding.Default))
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
            try
            {
                Award temp = FindAward(name);
                Awards.Remove(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(int id)
        {
            try
            {
                Award temp = FindAward(id);
                Awards.Remove(temp);
                return true;
            }
            catch
            {
                return false;
            }
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
            using (StreamWriter sr = new StreamWriter(@"awards.txt"))
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
