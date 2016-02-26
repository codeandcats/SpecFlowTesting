namespace BookFace.Core.Infrastructure
{
    public interface IHandler<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest request);
    }

    public abstract class BaseHandler<TRequest, TResponse> : IHandler<TRequest, TResponse>
    {
        protected BaseHandler(IHandlerContext context)
        {
            Context = context;
        }

        protected IHandlerContext Context { get; set; }

        public abstract TResponse Handle(TRequest request);
    }

    public interface ICommandHandler<in TRequest>
    {
        void Handle(TRequest request);
    }

    public abstract class BaseCommandHandler<TRequest> : ICommandHandler<TRequest>
    {
        protected BaseCommandHandler(IHandlerContext context)
        {
            Context = context;
        }

        protected IHandlerContext Context { get; private set; }

        public abstract void Handle(TRequest request);
    }
}
