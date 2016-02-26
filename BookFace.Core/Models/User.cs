using System.Collections.Generic;

namespace BookFace.Core.Models
{
    public interface IUser
    {
        string UserName { get; set; }
        List<string> FriendNames { get; set; }
    }

    public class User : IUser
    {
        public string UserName { get; set; }
        public List<string> FriendNames { get; set; }
    }
}