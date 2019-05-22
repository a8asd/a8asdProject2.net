using System;
using System.Collections.Generic;
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
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Driver> drivers = new Dictionary<string, Driver>();

        [Given(@"(.*) is a registered customer")]
        public void GivenARegisteredCustomer(string name)
        {
            customers[name] = new Customer {Name = name};
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenAnAvailableDriver(string driverName)
        {
            drivers[driverName] = new Driver {Name = driverName};
        }
            
        [When(@"(.*) books a ride with (.*)")]
        public void WhenCustomerBooksARide(string customerName, string driverName)
        {
            booking = new Booking {Customer = customers[customerName], Driver=drivers[driverName]};
        }
        
        [Then(@"(.*) is booked to (.*)")]
        public void ThenCharlieIsBookedToPat(string driverName, string customerName)
        {
            Assert.AreEqual(customers[customerName], booking.Customer);
            Assert.AreEqual(drivers[driverName], booking.Driver);
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
