using System.Collections.Generic;

namespace BookFace.Core
{
    public class User
    {
        public string UserName { get; set; }
        public List<User> Friends { get; set; }
    }
}