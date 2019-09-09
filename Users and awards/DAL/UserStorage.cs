using Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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
            Users.Add(new User(name, dateofbirth));
            return true;
        }

        public ICollection<User> GetAll()
        {
            return Users;
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

        public bool Remove(User note)
        {
            if (Find(note))
            {
                Users.Remove(note);
                return true;
            }
            return false;
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
                foreach(var item in Users)
                {
                    sr.WriteLine($"{item.Id}*{item.Name}*{item.DateOfBirth}");
                }
            }
        }
    }

}
