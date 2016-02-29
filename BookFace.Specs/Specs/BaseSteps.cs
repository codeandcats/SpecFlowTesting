using BookFace.Core.Data;
using BookFace.Core.Infrastructure;
using BookFace.Specs.Infrastructure.ValueRetrievers;
using Ploeh.AutoFixture;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BookFace.Specs
{
    public class BaseSteps
    {
        protected IClock Clock;
        protected DataStore Store;
        protected Fixture Fixture;

        [BeforeScenario]
        public void BeforeScenario()
        {
            Service.Instance.RegisterValueRetriever(new FriendNamesValueRetriever());

            Clock = new Clock();

            Store = new DataStore();

            Fixture = new Fixture();
        }
    }
}
