using Microsoft.AspNet.Identity.EntityFramework;


namespace DatingProj.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public virtual ApplicationUser ToUser { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
      //  public virtual ApplicationUser 
    }
}