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
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Friend> Friends { get; set; }
    }

    public class MyInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var store = new UserStore<ApplicationUser>(context);
            var userManager = new ApplicationUserManager(store);
            var user = new ApplicationUser { UserName = "admin@mail.com", Email = "admin@mail.com" };
            string filename = Path.Combine(HttpRuntime.AppDomainAppPath, "Images/NoImg.jpg");
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(filename);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            user.UserPhoto = imageData;
            userManager.CreateAsync(user, "Password").Wait();

            base.Seed(context);

        }
    }
}
