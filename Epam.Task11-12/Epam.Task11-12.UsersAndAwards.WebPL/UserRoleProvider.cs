using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Epam.Task11_12.UsersAndAwards.Common;

namespace Epam.Task11_12.UsersAndAwards.WebPL
{
    public class UserRoleProvider : RoleProvider
    {
        public override bool IsUserInRole(string username, string roleName)
        {
            return Array.IndexOf(GetRolesForUser(username), roleName) > -1;
        }

        public override string[] GetRolesForUser(string username)
        {
            return DependencyResolver.AccountsLogic.GetRoles(username);
        }

        #region NotImplemented

        public override string ApplicationName { get; set; }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}