using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Watermarks.Common;

namespace Watermarks.WebPL
{
    public class MyRoleProvider : RoleProvider
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            rolelogic.AddUsersToRoles(usernames, roleNames);
        }

        public override void CreateRole(string roleName)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            rolelogic.CreateRole(roleName);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            return rolelogic.DeleteRole(roleName, throwOnPopulatedRole);
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            return rolelogic.FindUsersInRole(roleName, usernameToMatch);
        }

        public override string[] GetAllRoles()
        {
            var rolelogic = DependencyResolver.RoleLogic;
            return rolelogic.GetAllRoles();
        }

        public override string[] GetRolesForUser(string username)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            return rolelogic.GetRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            return rolelogic.GetUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            return rolelogic.IsUserInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            rolelogic.RemoveUsersFromRoles(usernames, roleNames);
        }

        public override bool RoleExists(string roleName)
        {
            var rolelogic = DependencyResolver.RoleLogic;
            return rolelogic.RoleExists(roleName);
        }
    }
}