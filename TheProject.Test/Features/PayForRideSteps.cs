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
        private int _distance;
        private double _ratePerMile;

        [Given(@"Pat has travelled (.*) miles with Charlie")]
        public void GivenPatHasTravelledMilesWithCharlie(int miles)
        {
            _distance = miles;
        }
        
        [Given(@"the rate is £(.*) per mile")]
        public void GivenTheRateIsPerMile(double rate)
        {
            _ratePerMile = rate;
        }
        
        [When(@"Pat pays for the ride")]
        public void WhenPatPaysForTheRide()
        {
            invoices.Add(new Invoice
            {
                payee = "Pat",
                driver = "Charlie",
                distance = _distance,
                amount = _ratePerMile * _distance
            });
        }

        public IList<Invoice> invoices { get; set; } = new List<Invoice>();

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
