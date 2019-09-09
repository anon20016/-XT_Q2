using Entities;
using System;
using System.Collections.Generic;
using System.IO;


namespace DAL
{
    public class AssotiationStorage : IStorable<Association>
    {
        List<Association> Assotiations = new List<Association>();

        public bool Add(Association note)
        {
            Assotiations.Add(note);
            return true;
        }
        public bool Find(Association note)
        {
            return Assotiations.Contains(note);
        }

        public void Load()
        {
            if (File.Exists(@"assotiations.txt"))
            {
                using (StreamReader sr = new StreamReader(@"assotiations.txt", System.Text.Encoding.Default))
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
            throw new NotImplementedException();
        }

        public ICollection<Association> GetAll()
        {
            return Assotiations;
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Association Find(int id)
        {
            throw new NotImplementedException();
        }
    }
}
