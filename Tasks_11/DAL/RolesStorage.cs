using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Entities;
using Entities.Interfaces;

namespace DAL
{
    public class RolesStorage : IRoleStore
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
            Role.count--;
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
           foreach(var item in Data)
            {
                if (item.Name == note.Name)
                {
                    return item.Id;
                }
            }
            return -1;
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

        private int FindIndex(string role)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                if (Data[i].Name == role)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsUserInRole(string username, string roleName)
        {
            int index = FindIndex(roleName);
            if (index != -1)
            {
                return Data[index].Users.Contains(username);
            }
            else
            {
                throw new ArgumentException("No such role");
            }
        }
        public bool IsUserInRole(string username, int roleIndex)
        {           
            return Data[roleIndex].Users.Contains(username);           
        }

        public string[] GetRolesForUser(string username)
        {
            List<string> res = new List<string>();
            foreach(var item in Data)
            {
                if (item.Users.Contains(username))
                {
                    res.Add(item.Name);
                }
            }
            return res.ToArray();
        }

        public string[] GetUsersInRole(string roleName)
        {
            int index = FindIndex(roleName);
            if (index != -1)
            {
                return Data[index].Users.ToArray();
            }
            else
            {
                throw new ArgumentException("No such role");
            }
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            foreach(var role in roleNames)
            {
                int index = FindIndex(role);
                if (index != -1)
                {
                    foreach (var user in usernames)
                    {
                        if (!IsUserInRole(user, index))
                        {
                            Data[index].Users.Add(user);
                        }
                    }
                }                
            }
        }

        public string[] GetAllRoles()
        {
            List<string> res = new List<string>();
            foreach(var item in Data)
            {
                res.Add(item.Name);
            }
            return res.ToArray();
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var role in roleNames)
            {
                int index = FindIndex(role);
                if (index != -1)
                {
                    foreach (var user in usernames)
                    {
                        if (IsUserInRole(user, index))
                        {
                            Data[index].Users.Remove(user);
                        }
                    }
                }
            }
        }

        public bool RoleExists(string roleName)
        {
            return FindIndex(roleName) != -1;
        }


    }
}
