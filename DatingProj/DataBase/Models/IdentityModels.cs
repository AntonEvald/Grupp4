using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataBase.Models;

namespace DatingProj.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public byte[] UserPhoto { get; set; }
        public bool Searchable { get; set; }

        public virtual ICollection<Posts> posts { get; set; }
        public virtual ICollection<Friend> Senders { get; set; }
        public virtual ICollection<Friend> Receivers { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ViewModel
    {
        public ApplicationUser user { get; set; }
        public IEnumerable<ApplicationUser> users { get; set; }
    }

    public class Friend
    {
        public int ID { get; set; }
        public bool IsConfirmed { get; set; }
        [Key]
        [Column(Order = 1)]
        public string FriendFrom { get; set; }
        [Key]
        [Column(Order = 2)]
        public string FriendTo { get; set; }
    }


}