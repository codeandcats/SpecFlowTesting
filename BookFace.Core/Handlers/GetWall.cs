using System.Collections.Generic;
using System.Linq;
using BookFace.Core.Data.Queries;
using BookFace.Core.Infrastructure;
using BookFace.Core.Models;

namespace BookFace.Core.Handlers
{
    public static class GetWall
    {
        public class Request
        {
            public string UserName { get; set; }
        }

        public class Response
        {
            public List<Post> Posts { get; set; } 
        }

        public class Handler : BaseHandler<Request, Response>
        {
            public Handler(IHandlerContext context) : base(context) { }

            public override Response Handle(Request request)
            {
                var response = new Response
                {
                    Posts = new GetWallPostsQuery(request.UserName, Context.CurrentUser)
                        .Execute(Context.DataStore)
                        .ToList()
                };

                return response;
            }
        }
    }
}
