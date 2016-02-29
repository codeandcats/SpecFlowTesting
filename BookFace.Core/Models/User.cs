using System;
using System.Collections.Generic;

namespace BookFace.Core.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public List<Guid> FriendIds { get; set; }
    }
}