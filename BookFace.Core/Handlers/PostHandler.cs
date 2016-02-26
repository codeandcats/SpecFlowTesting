using BookFace.Core.Infrastructure;
using BookFace.Core.Models;

namespace BookFace.Core.Handlers
{
    public static class SubmitPost
    {
        public class Request
        {
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
                    Author = Context.CurrentUser,
                    PublishedDate = Context.Clock.Now,
                    Content = request.Content
                };

                Context.DataStore.Insert(post);
            }
        }
    }
}
