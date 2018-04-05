namespace CCS2.Migrations
{
    using CCS2.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.Security;
    using WebMatrix.WebData;

    internal sealed class Configuration : DbMigrationsConfiguration<CCS2.Models.CcsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CCS2.Models.CcsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            DummyData();

            context.Services.AddOrUpdate(
                new Service { Name = "Windows Applications", Brief = "Business solutions that will improve your productivity and efficiency.  Giving you more time to focus on your business.", Featured = true },
                new Service { Name = "Web Development", Brief = "Create or improve your web presence to better reach your customers or clients.  We create custom proffesional websites to meet your needs.", Featured = true },
                new Service { Name = "Mobile Solutions", Brief = "Looking to break into the mobile world?  We can make an app for your business for any of the current popular mobile devices.", Featured = true });
            context.SaveChanges();
            
        }
        

        private void DummyData()
        {
            WebSecurity.InitializeDatabaseConnection(
                "CyberSolutionsDB",
                "UserProfile",
                "UserProfileId",
                "username", autoCreateTables: true);

            if (!Roles.RoleExists("Administrator"))
                Roles.CreateRole("Administrator");

            if (!Roles.RoleExists("User"))
                Roles.CreateRole("User");

            if (!WebSecurity.UserExists("brian"))
                WebSecurity.CreateUserAndAccount(
                    "brian",
                    "Password1");

            if (!WebSecurity.UserExists("charlie"))
                WebSecurity.CreateUserAndAccount(
                    "charlie",
                    "Password1");

            if (!Roles.GetRolesForUser("brian").Contains("Administrator"))
                Roles.AddUsersToRole(new[] { "brian" }, "Administrator");

            if (!Roles.GetRolesForUser("charlie").Contains("User"))
                Roles.AddUsersToRole(new[] { "charlie" }, "User");
        }
    }
}
