using BookFace.Core.Data;
using BookFace.Core.Models;

namespace BookFace.Core.Infrastructure
{
    public interface IHandlerContext
    {
        IClock Clock { get; set; }
        IDataStore DataStore { get; set; }
        IUser CurrentUser { get; set; }
    }

    public class HandlerContext : IHandlerContext
    {
        public HandlerContext(IClock clock, IDataStore dataStore, IUser currentUser)
        {
            Clock = clock;
            DataStore = dataStore;
            CurrentUser = currentUser;
        }

        public IClock Clock { get; set; }
        public IDataStore DataStore { get; set; }
        public IUser CurrentUser { get; set; }
    }
}
