using DatingProj.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingProj;

namespace DataBase.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ApplicationUser>().HasMany(x => x.posts).WithRequired(x => x.ToUser);

            base.OnModelCreating(modelbuilder);
        }
        public DbSet<Posts> Posts { get; set; }
    }

    public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(store);
            var user = new ApplicationUser { UserName = "mail@mail.com", Email = "mail@mail.com" };
            userManager.CreateAsync(user, "User1").Wait();

            base.Seed(context);

        }
    }
}
