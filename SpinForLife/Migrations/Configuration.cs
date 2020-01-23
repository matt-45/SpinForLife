namespace SpinForLife.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SpinForLife.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SpinForLife.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }
            if (!context.Roles.Any(r => r.Name == "User"))
            {
                roleManager.Create(new IdentityRole { Name = "Manager" });
            }

            // user creation

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!context.Users.Any(u => u.Email == "mattpark102@outlook.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "mattpark102@outlook.com",
                    Email = "mattpark102@outlook.com",
                    FirstName = "Matthew",
                    LastName = "Park"
                }, "Eggegg12!");
            }

            // assign admin role

            var adminId = userManager.FindByEmail("mattpark102@outlook.com").Id;
            userManager.AddToRole(adminId, "Admin");
        }
    }
}
