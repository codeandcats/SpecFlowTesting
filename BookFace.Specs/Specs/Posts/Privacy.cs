using System;
using System.Linq;
using BookFace.Core.Data;
using BookFace.Core.Handlers;
using BookFace.Core.Infrastructure;
using BookFace.Core.Models;
using BookFace.Specs.Infrastructure.ValueRetrievers;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookFace.Specs.Posts
{
    [Binding]
    public class Privacy
    {
        private IDataStore _store;
        private readonly Fixture _fixture = new Fixture();

        [BeforeTestRun]
        public static void BeforeScenario()
        {
            Service.Instance.RegisterValueRetriever(new FriendNamesValueRetriever());
        }

        [Given]
        public void GivenTheFollowingUsers(Table table)
        {
            _store = new DataStore();

            var users = table.CreateSet<User>();

            foreach (var user in users)
            {
                _store.Insert(user);
            }
        }
        
        [When]
        public void When_USERNAME_CreatesAPostSharedWithFriends(string userName)
        {
            var request = _fixture.Create<SubmitPost.Request>();

            var context = new HandlerContext(
                new Clock(),
                _store,
                _store.Select<User>().First(u => u.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase)));

            var handler = new SubmitPost.Handler(context);

            handler.Handle(request);
        }
        
        [When]
        public void When_UserName_CreatesAPostSharedWithPublic(string userName)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void ThenTheFollowingUsersShouldBeAbleToSeeIt(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then]
        public void ThenTheFollowingUsersShouldNotBeAbleToSeeIt(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
