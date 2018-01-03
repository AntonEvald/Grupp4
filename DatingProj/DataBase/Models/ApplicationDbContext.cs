using DatingProj.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatingProj;
using System.IO;
using System.Web;

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
            modelbuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Senders)
                .WithRequired()
                .HasForeignKey(e => e.FriendTo)
                .WillCascadeOnDelete(false);

            modelbuilder.Entity<ApplicationUser>()
                .HasMany(e => e.Receivers)
                .WithRequired()
                .HasForeignKey(e => e.FriendFrom)
                .WillCascadeOnDelete(true);
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }

      //  public System.Data.Entity.DbSet<DatingProj.Models.ApplicationUser> ApplicationUsers { get; set; }
    }

    public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            string path = Path.Combine(HttpRuntime.AppDomainAppPath, @"Images/noavatar.png");
            var pic = File.ReadAllBytes(path);
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(store);
            var user1 = new ApplicationUser { Name = "Admin Adminsson", UserName = "admin@mail.com", Email = "admin@mail.com", UserPhoto = pic, Searchable = true};
            var user2 = new ApplicationUser { Name = "Sven Svensson", UserName = "sven@mail.com", Email = "sven@mail.com", UserPhoto = pic , Searchable = true};
            var user3 = new ApplicationUser { Name = "Johan Johansson", UserName = "johan@mail.com", Email = "johan@mail.com", UserPhoto = pic, Searchable = true};
            userManager.CreateAsync(user1, "Asd123!").Wait();
            userManager.CreateAsync(user2, "Asd123!").Wait();
            userManager.CreateAsync(user3, "Asd123!").Wait();

            base.Seed(context);

        }
    }
}
