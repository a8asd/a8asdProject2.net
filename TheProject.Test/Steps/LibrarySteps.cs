using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TheProject.Test.Steps
{
    [Binding]
    public sealed class LibrarySteps
    {
        private readonly Dictionary<string, Member>people = new Dictionary<string, Member>();
        private readonly Library library= new Library();

        [Given(@"(.*) is a member")]
        public void GivenAMember(string name)
        {
            people[name] = new Member {Username = name,Password="wordpass"};
            library.AddMember(people[name]);
        }
        
        [When(@"(.*) logs in")]
        public void WhenMemberLogsIn(string username)
        {
            library.Login(username, people[username].Password);
        }
        
        [Then(@"(.*) should be logged in")]
        public void ThenMemberShouldBeLoggedIn(string username)
        {
            Assert.IsTrue(people[username].IsLoggedIn);
        }
    }
}
