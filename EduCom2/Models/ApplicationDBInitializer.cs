using EduComDataLayer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace EduCom2.Models
{
    public class ApplicationDBInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        public ApplicationDBInitializer()
        {
        }
        protected override void Seed(ApplicationDbContext context)
        {
            var manager =
                            new UserManager<ApplicationUser>(
                                new UserStore<ApplicationUser>(context));


            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Admin" }
                );
            context.Roles.AddOrUpdate(r => r.Name,
                new IdentityRole { Name = "Member" }
                );
         

            PasswordHasher ps = new PasswordHasher();

            context.Users.AddOrUpdate(a => new { a.FirstName, a.SecondName },
                new ApplicationUser[] {
               new ApplicationUser
                {
                    UserName = "s00173508@mail.itsligo.ie",
                    Email = "s00173508@mail.itsligo.ie",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    FirstName = "Rebecca",
                    SecondName = "McGlynn",
                    Programme="Software",
                    Year="3",
                    StudentNumber="S00173508",
                    PasswordHash = ps.HashPassword("Rosesean@1")
                },

               new ApplicationUser
                {
                    UserName = "s00173510@mail.itsligo.ie",
                    Email = "s00173510@mail.itsligo.ie",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    FirstName = "Marek",
                    SecondName = "Kiejza",
                    Programme="Software",
                    Year="3",
                    StudentNumber="S00173510",
                    PasswordHash = ps.HashPassword("Marek@1")
                },

               new ApplicationUser
                {
                    UserName = "s00173498@mail.itsligo.ie",
                    Email = "s00173498@mail.itsligo.ie",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    FirstName = "Stephen",
                    SecondName = "Brett",
                    Programme="Software",
                    Year="3",
                    StudentNumber="S00173498",
                    PasswordHash = ps.HashPassword("Stephen@1")
                },

               new ApplicationUser
                {
                    UserName = "s00167887@mail.itsligo.ie",
                    Email = "s00167887@mail.itsligo.ie",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EmailConfirmed = true,
                    FirstName = "Aoife",
                    SecondName = "Egan",
                    Programme="Software",
                    Year="3",
                    StudentNumber="S00167887",
                    PasswordHash = ps.HashPassword("Aoife@1")
                },


                }
                    );
            context.SaveChanges();
            //Asign Roles

            ApplicationUser ChosenAdmin = manager.FindByEmail("s00173508@mail.itsligo.ie");
            if (ChosenAdmin != null)
            {
                manager.AddToRoles(ChosenAdmin.Id, new string[] { "Admin","Member" });
            }
            ChosenAdmin = manager.FindByEmail("s00173510@mail.itsligo.ie");
            if (ChosenAdmin != null)
            {
                manager.AddToRoles(ChosenAdmin.Id, new string[] { "Admin", "Member" });
            }
            ChosenAdmin = manager.FindByEmail("s00173498@mail.itsligo.ie");
            if (ChosenAdmin != null)
            {
                manager.AddToRoles(ChosenAdmin.Id, new string[] { "Admin", "Member" });
            }
            ChosenAdmin = manager.FindByEmail("s00167887@mail.itsligo.ie");
            if (ChosenAdmin != null)
            {
                manager.AddToRoles(ChosenAdmin.Id, new string[] { "Admin", "Member" });
            }
            base.Seed(context);

        }

        //private void SeedMemberUsers(ApplicationDbContext context)
        //{
        //    EduContext ectx = new EduContext(); // Note this call will trigger the database initialiser for BusinessContext
        //                                        // The first time around
        //                                        // Create and Attach Account Managers to the Accounts

        //    var roles = context.Roles;
        //    if (roles.Any())
        //    {
        //        var users = context.Users.ToList();
        //        // Get users in roles
        //        var AccountManagers = (from c in users
        //                               where c.Roles.Any(r => r.RoleId == roles.First().Id)
        //                               select c);
        //        // Assign a random user to a company
        //        foreach (var person in ectx.Members)
        //        {
        //            // Select a random account manager id
        //            person.MemberID = AccountManagers
        //                .Select(m => new { id = m.Id, order = Guid.NewGuid().ToString() })
        //                .OrderBy(o => o.order)
        //                .Select(r => r.id)
        //                .First();
        //        }
        //    }
        //    ectx.SaveChanges();
        //}
    }
}
    