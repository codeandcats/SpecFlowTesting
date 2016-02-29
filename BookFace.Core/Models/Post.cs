using System;

namespace BookFace.Core.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public DateTime PublishedDate { get; set; }
        public PrivacyScope Scope { get; set; }
        public string Content { get; set; }
    }
}
