using System;
using BookFace.Core.Infrastructure;
using BookFace.Core.Models;

namespace BookFace.Core.Handlers
{
    public static class SubmitPost
    {
        public class Request
        {
            public PrivacyScope Scope { get; set; }
            public string Content { get; set; }
        }

        public class Response
        {
        }

        public class Handler : BaseCommandHandler<Request>
        {
            public Handler(IHandlerContext context) : base(context) { }

            public override void Handle(Request request)
            {
                var post = new Post
                {
                    Id = Guid.NewGuid(),
                    AuthorId = Context.CurrentUser.Id,
                    PublishedDate = Context.Clock.Now,
                    Scope = request.Scope,
                    Content = request.Content
                };

                Context.DataStore.Insert(post);
            }
        }
    }
}
