using BookFace.Core.Data;

namespace BookFace.Core.Handlers
{
    public static class SubmitPost
    {
        public class Request
        {
        }

        public class Response
        {
        }

        public class Handler : IHandler<Request, Response>
        {
            private IDataStore _store;

            public Handler(IDataStore store)
            {
                _store = store;
            }

            public Response Handle(Request request)
            {
                _store.Insert()
            }
        }
    }
}
