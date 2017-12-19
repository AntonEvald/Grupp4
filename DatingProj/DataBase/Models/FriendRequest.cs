namespace DatingProj.Models
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public ApplicationUser ToUser { get; set; }
        public ApplicationUser FromUser { get; set; }
        public virtual ApplicationUser 
    }
}