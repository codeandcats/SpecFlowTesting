namespace BookFace.Core.Handlers
{
    public interface IHandler<in TRequest, out TResponse>
    {
        TResponse Handle(TRequest input);
    }
}
