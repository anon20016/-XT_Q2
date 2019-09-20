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
            if (note.Id == -1)
            {
                foreach (var item in Data)
                {
                    if (item.Login == note.Login && note.Hash == item.Hash)
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                foreach (var item in Data)
                {
                    if (item.Login == note.Login)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public bool Contains(LoginData note)
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
            foreach (var item in Data)
            {
                if (item.Id == id)
                {                    
                    return item;
                }
            }
            return null;
        }

        public int Find(LoginData note)
        {
            foreach(var item in Data)
            {
                if (note.Login == item.Login)
                {
                    return item.Id;
                }
            }
            return -1;
        }

        public ICollection<LoginData> GetAll()
        {
            return Data;
        }        

        public bool Remove(LoginData note)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int id)
        {
            foreach(var item in Data)
            {
                if (item.Id == id)
                {
                    Data.Remove(item);
                    return true;
                }
            }
            return false;
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
                        if (t.Length == 3)
                        {
                            Data.Add(new LoginData(Convert.ToInt32(t[0]), t[1], t[2]));                            
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
                    sr.WriteLine($"{item.Id}*{item.Login}*{item.Hash}");
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
