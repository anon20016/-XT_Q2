using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BAL;
using Entities;

namespace Task10_5.Models
{
    public class MyRoleProvider : RoleProvider
    {
        private Dictionary<string, List<string>> all = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> roles = new Dictionary<string, List<string>>();

        public MyRoleProvider(){
            RoleLogic roleLogic = new RoleLogic(System.Web.Hosting.HostingEnvironment.MapPath("~/Data/roles.txt"));
            roleLogic.LoadData();
            all = roleLogic.GetU();
            roles = roleLogic.GetR();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            if (all.ContainsKey(username) && all[username].Contains(roleName))
            {              
                return true;                
            }
            return false;
        }        

        public override string[] GetRolesForUser(string username)
        {
            if (all.ContainsKey(username))
            {
                return all[username].ToArray();
            }
            else
            {
                return null;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            if (roles.ContainsKey(roleName))
                return roles[roleName].ToArray();
            return null;
        }
        
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            
            foreach(var user in usernames)
            {
                if (!all.ContainsKey(user))
                {
                    all.Add(user, new List<string>());
                }
                foreach(var role in roleNames)
                {
                    if (!roles.ContainsKey(role))
                    {
                        roles.Add(role, new List<string>());
                    }
                    roles[role].Add(user);
                    all[user].Add(role);
                }
            }
        }

        public override void CreateRole(string roleName)
        {
            roles.Add(roleName, new List<string>());
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            return roles.Keys.ToArray();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            foreach (var user in usernames)
            {
                if (!all.ContainsKey(user))
                {
                    continue;
                }
                foreach (var role in roleNames)
                {
                    if (!roles.ContainsKey(role))
                    {
                        continue;
                    }
                    roles[role].Remove(user);
                    all[user].Remove(role);
                }
            }
        }

        public override bool RoleExists(string roleName)
        {
            return roles.ContainsKey(roleName);
        }
    }
}