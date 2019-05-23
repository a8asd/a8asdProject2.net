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
        private string _customer;
        private string _driverName;
        public IList<Journey> bookedJournes { get; set; } = new List<Journey>();

        [Given(@"(.*) has travelled (.*) miles with (.*)")]
        public void GivenPatHasTravelledMilesWithCharlie(string passenger, int miles, string driverName)
        {
            _distance = miles;
            _customer = passenger;
            _driverName = driverName;
            bookedJournes.Add(new Journey { 
                payee = passenger,
                driver = driverName,
                distance = miles
            });
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
                payee = _customer,
                driver = _driverName,
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

        [Given(@"these journeys")]
        public void GivenTheseJourneys(Table table)
        {
            table.CompareToSet(bookedJournes);
        }


        

        [Given(@"the rates are")]
        public void GivenTheRatesAre(Table table)
        {

        }

    }

    public class Invoice : Journey
    {
        public double amount { get; internal set; }
    }

    public class Journey
    {
        public string payee { get; internal set; }
        public string driver { get; internal set; }
        public int distance { get; internal set; }

    }
}
