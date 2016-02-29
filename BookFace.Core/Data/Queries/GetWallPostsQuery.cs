using System.Collections.Generic;
using System.Linq;
using BookFace.Core.Infrastructure.Extensions;
using BookFace.Core.Models;

namespace BookFace.Core.Data.Queries
{
    public class GetWallPostsQuery : IQuery<IEnumerable<Post>>
    {
        private readonly string _forUserName;
        private readonly User _viewer;

        public GetWallPostsQuery(string forUserName, User viewer)
        {
            _forUserName = forUserName;
            _viewer = viewer;
        }

        public IEnumerable<Post> Execute(IDataStore store)
        {
            var author = store.Select<User>().First(u => u.UserName.EqualsIgnoreCase(_forUserName));
            var viewer = store.Select<User>().First(u => u.UserName == _viewer.UserName);

            var areFriends = author.FriendIds.Any(n => n == _viewer.Id);

            var posts = store
                .Select<Post>()
                .Where(p =>
                    p.AuthorId == viewer.Id 
                    || p.Scope == PrivacyScope.Public 
                    || areFriends
                );

            return posts;
        }
    }
}
