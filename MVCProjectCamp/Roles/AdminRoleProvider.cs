using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace MVCProjectCamp.Roles
{
    public class AdminRoleProvider : RoleProvider  //bu kısımda database'e eklediğimiz rolleri tanımlıyoruz. RoleProvider yazdıktan sonra using yapıyoruz. ayrıca AdminRoleProvider bize sağladığı yardımcı metodları implemente ediyoruz.
    {
        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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

        public override string[] GetRolesForUser(string username)  //bizim işimize yarayacak metod burası, bu blok sayesinde roll ataması yapabileceğiz.
        {
            Context c = new Context();
            var x = c.Admins.FirstOrDefault(a => a.AdminUsername == username);
            return new string[] { x.AdminRole };
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
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
    }
}