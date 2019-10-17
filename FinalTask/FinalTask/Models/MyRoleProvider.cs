using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace FinalTask.Models
{
    public class MyRoleProvider : RoleProvider
    {      
        public override bool IsUserInRole(string username, string roleName)
        {
        }        

        public override string[] GetRolesForUser(string username)
        {

        }

        public override string[] GetUsersInRole(string roleName)
        {
        }
        
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
           
        }

        public override void CreateRole(string roleName)
        {
            
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
           
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            
        }

        public override bool RoleExists(string roleName)
        {
            
        }
    }
}