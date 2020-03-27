using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcWebUI.Identity
{
    public class IdentityInitializer : DropCreateDatabaseIfModelChanges<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i => i.Name == "Admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name = "Admin", Description= "Admin role"
                };
                manager.Create(role);
            }

        
            if (!context.Roles.Any(i => i.Name == "User"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole()
                {
                    Name="User", Description="User role"
                };
                manager.Create(role);
            }


            if (!context.Roles.Any(i => i.Name == "elvinabra"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
Name = "Elvin", Surname="Ibrahimov", UserName = "elvinabra", Email= "evis.elis71@gmail.com"
                };
                manager.Create(user, "eminem01");
                manager.AddToRole(user.Id, "Admin");
                manager.AddToRole(user.Id, "User");
            }

            if (!context.Roles.Any(i => i.Name == "feridibrahimov"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "Ferid",
                    Surname = "Ibrahimov",
                    UserName = "feridibrahimov",
                    Email = "evis.elis70@gmail.com"
                };
                manager.Create(user, "eminem01");
                manager.AddToRole(user.Id, "User");
            }
       base.Seed(context);
        }
    }
}