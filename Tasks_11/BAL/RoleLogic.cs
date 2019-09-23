using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using DAL;
using Entities.Interfaces;

namespace BAL
{
    public class RoleLogic : IRoleLogic
    {
        private IRoleStore MemoryStorage;
        private string path = @"C:\Temp\Users.txt";

        public RoleLogic(string p)
        {
            path = p;
            MemoryStorage = new RolesStorage(path);
        }     

        public bool IsUserInRole(string username, string roleName)
        {
            return MemoryStorage.IsUserInRole(username, roleName);
        }

        public string[] GetRolesForUser(string username)
        {
            return MemoryStorage.GetRolesForUser(username);
        }

        public string[] GetUsersInRole(string roleName)
        {
            return MemoryStorage.GetUsersInRole(roleName);
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            MemoryStorage.AddUsersToRoles(usernames, roleNames);
        }

        public void CreateRole(string roleName)
        {
            if (!MemoryStorage.Add(new Role(++Role.count, roleName)))
            {
                throw new ArgumentException("Already exists");
            }  
        }

        public bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (!MemoryStorage.Remove(MemoryStorage.Find(new Role(-1, roleName))))
            {
                throw new ArgumentException("Already exists");
            }
            else
            {
                return true;
            }
        }

        public string[] GetAllRoles()
        {
            return MemoryStorage.GetAllRoles();
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            MemoryStorage.RemoveUsersFromRoles(usernames, roleNames);
        }

        public bool RoleExists(string roleName)
        {
            return MemoryStorage.RoleExists(roleName);
        }

        public void SaveData()
        {
            MemoryStorage.Save();
        }
        public void LoadData()
        {
            MemoryStorage.Load();
        }
    }
}
