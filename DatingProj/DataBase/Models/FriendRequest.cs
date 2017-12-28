using System;
using DatingProj.Models;

namespace DataBase.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public virtual ApplicationUser ToUser { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
        public virtual FriendRequestFlags Flags { get; set; }
    }

    [Flags]
    public enum FriendRequestFlags
    {
        Pending,
        Approved,
        Rejected
    }
}