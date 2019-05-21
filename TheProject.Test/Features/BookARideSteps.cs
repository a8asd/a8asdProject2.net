using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookARideSteps
    {
        private Customer pat;
        private Booking booking;
        private Driver charlie;

        [Given(@"(.*) is a registered customer")]
        public void GivenARegisteredCustomer(string name)
        {
            pat = new Customer {Name = name};
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenAnAvailableDriver(string name)
        {
            charlie = new Driver {Name = name};
        }
            
        [When(@"Pat books a ride")]
        public void WhenBookARide()
        {
            booking = new Booking {Customer = pat, Driver=charlie};
        }
        
        [Then(@"Charlie is booked to Pat")]
        public void ThenCharlieIsBookedToPat()
        {
            Assert.AreEqual(pat, booking.Customer);
            Assert.AreEqual(charlie, booking.Driver);
        }
    }

    internal class Driver
    {
        public string Name { get; set; }
    }

    internal class Booking
    {
        public Customer Customer { get; set; }
        public Driver Driver { get; set; }
    }

    internal class Customer
    {
        public string Name { get; set; }
    }
}
