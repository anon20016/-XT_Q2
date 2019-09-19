using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Entities;

namespace DAL
{
    public class RolesStorage : IStorable<Role>
    {
        public string Path { get; set; }
        private List<Role> Data;

        public RolesStorage(string p)
        {
            Path = p;
            Data = new List<Role>();
        }

        public bool Add(Role note)
        {
            if (!Exists(note))
            {
                Data.Add(note);
                return true;
            }
            return false;
        }

        public bool Exists(Role note)
        {
            foreach(var item in Data)
            {
                if (note.Name == item.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public Role Find(int id)
        {
            foreach(var item in Data)
            {
                if  (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public int Find(Role note)
        {
            throw new NotImplementedException();
        }

        public ICollection<Role> GetAll()
        {
            return Data;
        }
              
        public bool Remove(Role note)
        {
            if (Exists(note))
            {
                Data.Remove(Find(note.Id));
                return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            if (Find(id) != null)
            {
                Data.Remove(Find(id));
                return true;
            }
            return false;
        }

        public bool Update(int id, Role note)
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
                        List<string> temp = new List<string>();
                        for (int i = 2; i < t.Length;i++)
                        {
                            temp.Add(t[i]);
                        }
                        Data.Add(new Role(Convert.ToInt32(t[0]), t[1], temp));
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
                    string temp = $"{item.Id}*{item.Name}";
                    foreach(var p in item.Users)
                    {
                        temp += "*" + p;
                    }
                    sr.WriteLine(temp);
                }
            }
        }


    }
}
