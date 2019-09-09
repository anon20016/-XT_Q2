using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DAL
{
    public class UserStorage : IStorable<User>
    {
        private List<User> Users { get; set; }
        public UserStorage()
        {
            Users = new List<User>();
        }

        public bool Add(User note)
        {
            Users.Add(note);
            return true;
        }

        public bool Add(string name, string dateofbirth)
        {
            Users.Add(new User(User.count, name, dateofbirth));
            return true;
        }

        User FindUser(string name, string dateofbirth)
        {
            var r = from item in Users where ((item.Name == name) && (item.DateOfBirth == dateofbirth)) select item;
            if (r.Count() > 0)
            {
                return r.First();
            }
            else
            {
                throw new FormatException("Error");
            }
        }
        User FindUser(int id)
        {
            var r = from item in Users where ((item.Id == id)) select item;
            if (r.Count() > 0)
            {
                return r.First();
            }
            else
            {
                throw new FormatException("Error");
            }
        }

        public bool Find(User note)
        {
            foreach (var item in Users)
            {
                if (item == note)
                {
                    return true;
                }
            }
            return false;
        }
        public User Find(int id)
        {
            return FindUser(id);
        }

        public bool Remove(User note)
        {
            if (note.Id == -1)
            {
                return Remove(note.Name, note.DateOfBirth);
            }
            else
            {
                return Remove(note.Id);
            }
        }
        public bool Remove(int id)
        {
            try
            {
                User temp = FindUser(id);
                Users.Remove(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Remove(string name, string dateofbirth)
        {
            try
            {
                User temp = FindUser(name, dateofbirth);
                Users.Remove(temp);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Load()
        {
            if (File.Exists(@"data.txt"))
            {
                int mxID = 0;
                using (StreamReader sr = new StreamReader(@"data.txt", System.Text.Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] t = line.Split('*');
                        if (t.Length == 3)
                        {
                            int temp = System.Convert.ToInt32(t[0]);
                            Users.Add(new User(temp, t[1], t[2]));
                            if (temp > mxID)
                            {
                                mxID = temp;
                            }
                        }
                    }

                    User.count = mxID + 1;
                }
            }
        }
        public void Save()
        {
            using (StreamWriter sr = new StreamWriter(@"data.txt"))
            {
                foreach (var item in Users)
                {
                    sr.WriteLine($"{item.Id}*{item.Name}*{item.DateOfBirth}");
                }
            }
        }

        public ICollection<User> GetAll()
        {
            return Users;
        }
    }

}
