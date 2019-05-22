using System;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    public class PayForRideSteps
    {
        [Given(@"Pat has travelled (.*) miles with Charlie")]
        public void GivenPatHasTravelledMilesWithCharlie(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the rate is £(.*) per mile")]
        public void GivenTheRateIsPerMile(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Pat pays for the ride")]
        public void WhenPatPaysForTheRide()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"these are the invoices in the system")]
        public void ThenTheseAreTheInvoicesInTheSystem(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
