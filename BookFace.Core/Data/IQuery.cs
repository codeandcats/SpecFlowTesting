namespace BookFace.Core.Data
{
    public interface IQuery<out T>
    {
        T Execute(IDataStore store);
    }
}
