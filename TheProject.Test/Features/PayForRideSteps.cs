using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class PayForRideSteps
    {
        public Invoice invoiceshistory = new Invoice();
        [Given(@"Pat has travelled (.*) miles with Charlie")]
        public void GivenPatHasTravelledMilesWithCharlie(int p0)
        {
            
        }
        
        [Given(@"the rate is £(.*) per mile")]
        public void GivenTheRateIsPerMile(int p0)
        {
            
        }
        
        [When(@"Pat pays for the ride")]
        public void WhenPatPaysForTheRide()
        {
            
        }
        
        [Then(@"these are the invoices in the system")]
        public void ThenTheseAreTheInvoicesInTheSystem(Table expectedInvoice)
        {

            IList<Invoice> invoices = new List<Invoice>
            {
                new Invoice
                {
                    payee = "Pat",
                    driver = "Charlie",
                    distance = 10,
                    amount = 20.00
                }
            };

            expectedInvoice.CompareToSet(invoices);
        }
    }

    public class Invoice
    {
        public string payee { get; internal set; }
        public string driver { get; internal set; }
        public int distance { get; internal set; }
        public double amount { get; internal set; }
    }
}
