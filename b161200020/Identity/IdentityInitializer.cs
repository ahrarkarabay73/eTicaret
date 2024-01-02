using b161200020.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace b161200020.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {

            //roller
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", UserDescription = "Admin Role" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="user", UserDescription="User Role" };
                manager.Create(role);
            }


            if (!context.Users.Any(i => i.Name == "ahrar"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name="ahrar", UserSurname="Karabay", UserName="ahrar", Email="ahrar.karabay@ogr.sakarya.edu.tr" };
                manager.Create(user, "1234567");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
                context.SaveChanges();
            }
            if (!context.Users.Any(i => i.Name == "user"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "user", UserSurname = "user", UserName = "user", Email = "user@user.com" };
                manager.Create(user,"1234567");
                manager.AddToRole(user.Id, "user");
                context.SaveChanges();
            }
            base.Seed(context);

        }
    }
}