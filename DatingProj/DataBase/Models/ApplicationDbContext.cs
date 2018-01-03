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
            var user4 = new ApplicationUser { Name = "Admin Adminsson", UserName = "ja@mail.com", Email = "ja@mail.com", UserPhoto = pic, Searchable = true };
            var user5 = new ApplicationUser { Name = "Admin Adminsson", UserName = "min@mail.com", Email = "min@mail.com", UserPhoto = pic, Searchable = true };
            var user6 = new ApplicationUser { Name = "Admin Adminsson", UserName = "adin@mail.com", Email = "adin@mail.com", UserPhoto = pic, Searchable = true };
            var user7 = new ApplicationUser { Name = "Admin Adminsson", UserName = "admn@mail.com", Email = "admn@mail.com", UserPhoto = pic, Searchable = true };
            var user8 = new ApplicationUser { Name = "Admin Adminsson", UserName = "ada@mail.com", Email = "ada@mail.com", UserPhoto = pic, Searchable = true };
            var user9 = new ApplicationUser { Name = "Admin Adminsson", UserName = "adn@mail.com", Email = "adn@mail.com", UserPhoto = pic, Searchable = true };
            var user10 = new ApplicationUser { Name = "Admin Adminsson", UserName = "asd@mail.com", Email = "asd@mail.com", UserPhoto = pic, Searchable = true };
            var user11 = new ApplicationUser { Name = "Admin Adminsson", UserName = "asdf@mail.com", Email = "asdf@mail.com", UserPhoto = pic, Searchable = true };
            userManager.CreateAsync(user1, "Asd123!").Wait();
            userManager.CreateAsync(user2, "Asd123!").Wait();
            userManager.CreateAsync(user3, "Asd123!").Wait();
            userManager.CreateAsync(user4, "Asd123!").Wait();
            userManager.CreateAsync(user5, "Asd123!").Wait();
            userManager.CreateAsync(user6, "Asd123!").Wait();
            userManager.CreateAsync(user7, "Asd123!").Wait();
            userManager.CreateAsync(user8, "Asd123!").Wait();
            userManager.CreateAsync(user9, "Asd123!").Wait();
            userManager.CreateAsync(user10, "Asd123!").Wait();
            userManager.CreateAsync(user11, "Asd123!").Wait();

            base.Seed(context);

        }
    }
}
