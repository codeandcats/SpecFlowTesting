using System;

namespace BookFace.Core.Models
{
    public interface IPost
    {
        IUser Author { get; set; }
        DateTime PublishedDate { get; set; }
        string Content { get; set; }
    }

    public class Post : IPost
    {
        public IUser Author { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Content { get; set; }
    }
}
