using System;
using System.Collections.Generic;
using System.Linq;
using BookFace.Core.Handlers;
using BookFace.Core.Infrastructure;
using BookFace.Core.Infrastructure.Extensions;
using BookFace.Core.Models;
using Ploeh.AutoFixture;
using Shouldly;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookFace.Specs.Posts
{
    [Binding]
    public class Privacy : BaseSteps
    {
        public class UserRepresentation
        {
            public string UserName { get; set; }
            public List<string> FriendNames { get; set; }
        }

        private User _lastUserToCreatePost;
        private Post _lastCreatedPost;

        private User GetUser(string userName)
        {
            return Store.Select<User>().FirstOrDefault(u => u.UserName.EqualsIgnoreCase(userName));
        }

        private User GetOrCreateUser(string userName)
        {
            var user = GetUser(userName);

            if (user == null)
            {
                user = Fixture
                    .Build<User>()
                    .With(u => u.UserName, userName)
                    .With(u => u.FriendIds, new List<Guid>())
                    .Create();

                Store.Insert(user);
            }

            return user;
        }

        [Given]
        public void GivenTheFollowingUsers(Table table)
        {
            var users = table.CreateSet<UserRepresentation>();

            foreach (var user in users)
            {
                var actualUser = GetOrCreateUser(user.UserName);

                if (user.FriendNames.Count > 0)
                {
                    actualUser.FriendIds.AddRange(user.FriendNames.Select(f => GetOrCreateUser(f).Id));
                    Store.Update(actualUser);
                }
            }
        }
        
        [When]
        public void When_USERNAME_CreatesAPostSharedWith_SCOPE(string userName, PrivacyScope scope)
        {
            var currentUser = GetUser(userName);

            var request = Fixture
                .Build<SubmitPost.Request>()
                .With(r => r.Scope, scope)
                .Create();

            var context = new HandlerContext(Clock, Store, currentUser);

            var handler = new SubmitPost.Handler(context);

            handler.Handle(request);

            _lastUserToCreatePost = currentUser;

            _lastCreatedPost = Store.Select<Post>().OrderByDescending(p => p.PublishedDate).First();
        }

        public List<Post> GetWallPosts(string forUserName, string viewerUserName)
        {
            var currentUser = GetUser(viewerUserName);

            var context = new HandlerContext(Clock, Store, currentUser);

            var handler = new GetWall.Handler(context);

            var response = handler.Handle(new GetWall.Request { UserName = forUserName });

            return response.Posts;
        }

        [Then]
        public void ThenTheFollowingUsers_SHOULD_BeAbleToSeeIt(string should, Table table)
        {
            var shouldBeVisible = should.Trim().EqualsIgnoreCase("Should");

            var users = table.CreateSet<UserRepresentation>();

            foreach (var user in users)
            {
                var wallPosts = GetWallPosts(_lastUserToCreatePost.UserName, user.UserName);
                var canSeePost = wallPosts.Any(p => p.Id == _lastCreatedPost.Id);
                canSeePost.ShouldBe(shouldBeVisible);
            }
        }
    }
}
