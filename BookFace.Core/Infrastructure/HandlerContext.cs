using BookFace.Core.Data;
using BookFace.Core.Models;

namespace BookFace.Core.Infrastructure
{
    public interface IHandlerContext
    {
        IClock Clock { get; set; }
        IDataStore DataStore { get; set; }
        User CurrentUser { get; set; }
    }

    public class HandlerContext : IHandlerContext
    {
        public HandlerContext(IClock clock, IDataStore dataStore, User currentUser)
        {
            Clock = clock;
            DataStore = dataStore;
            CurrentUser = currentUser;
        }

        public IClock Clock { get; set; }
        public IDataStore DataStore { get; set; }
        public User CurrentUser { get; set; }
    }
}
