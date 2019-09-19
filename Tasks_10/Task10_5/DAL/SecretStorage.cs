using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Entities;

namespace DAL
{
    public class SecretStorage : IStorable<LoginData>
    {
        private List<LoginData> Data { get; set; }
        public string Path { get; set; }

        public SecretStorage(string p)
        {
            Path = p;
            Data = new List<LoginData>();
        }

        public bool Add(LoginData note)
        {
            if (!Contains(note))
            {
                Data.Add(note);
                return true;
            }
            return false;
        }

        public bool Exists(LoginData note)
        {
            return Data.Contains(note);
        }

        private bool Contains(LoginData note)
        {
            foreach(var item in Data)
            {
                if (note.Login == item.Login)
                {
                    return true;
                }                
            }
            return false;
        }

        public LoginData Find(int id)
        {
            throw new NotImplementedException();
        }

        public int Find(LoginData note)
        {
            throw new NotImplementedException();
        }

        public ICollection<LoginData> GetAll()
        {
            throw new NotImplementedException();
        }        

        public bool Remove(LoginData note)
        {
            return Data.Remove(note);
        }

        public bool Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            if (File.Exists(Path))
            {
                using (StreamReader sr = new StreamReader(Path, System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t = line.Split('*');
                        if (t.Length == 2)
                        {
                            Data.Add(new LoginData(t[0], t[1]));                            
                        }
                    }
                }
            }
        }
        public void Save()
        {
            if (!File.Exists(Path))
            {
                File.Create(Path);
            }
            using (StreamWriter sr = new StreamWriter(Path))
            {
                foreach (var item in Data)
                {
                    sr.WriteLine($"{item.Login}*{item.Hash}");
                }
            }
        }

        public bool Update(int id, LoginData note)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Login == note.Login)
                {
                    Data[i].Hash = note.Hash;
                    return true;
                }
            }
            return false;
        }
    }
}
