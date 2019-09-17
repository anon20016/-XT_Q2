using Entities;
using System;
using System.Collections.Generic;
using System.IO;


namespace DAL
{
    public class AssotiationStorage : IStorable<Association>
    {
        List<Association> Assotiations = new List<Association>();
        private string path { get; set; }

        public AssotiationStorage(string p)
        {
            path = p;
        }

        public bool Add(Association note)
        {
            if (!Exists(note))
            {
                Assotiations.Add(note);
                return true;
            }
            return false;
        }
        public bool Exists(Association note)
        {
            return Assotiations.Contains(note);
        }

        public void Load()
        {
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t = line.Split('*');
                        if (t.Length == 2)
                        {
                            Assotiations.Add(new Association(System.Convert.ToInt32(t[0]), System.Convert.ToInt32(t[1])));
                        }
                    }

                }
            }
        }

        public bool Remove(Association note)
        {
            if (note.firstID == -1)
            {
                List<Association> tmp = new List<Association>();
                foreach(var item in Assotiations)
                {
                    if (item.secondID != note.secondID)
                    {
                        tmp.Add(item);
                    }
                }
                Assotiations = tmp;
                return true;
            }
            if (note.secondID == -1)
            {
                List<Association> tmp = new List<Association>();
                foreach (var item in Assotiations)
                {
                    if (item.firstID != note.firstID)
                    {
                        tmp.Add(item);
                    }
                }
                Assotiations = tmp;
                return true;
            }
            if (Assotiations.Contains(note))
            {
                Assotiations.Remove(note);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Save()
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
            using (StreamWriter sr = new StreamWriter(path))
            {
                foreach (var item in Assotiations)
                {
                    sr.WriteLine($"{item.firstID}*{item.secondID}");
                }
            }
        }

        public ICollection<Association> GetAll()
        {
            return Assotiations;
        }
                
        public bool Remove(int x)
        {
            throw new NotImplementedException();
        }

        public Association Find(int id)
        {
            throw new NotImplementedException();
        }
        public int Find(Association note)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, Association note)
        {
            throw new NotImplementedException();
        }
    }
}
