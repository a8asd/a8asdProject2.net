using System;
using System.Collections.Generic;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookARideSteps
    {
        private Booking booking;
        private Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        private Dictionary<string, Customer> drivers = new Dictionary<string, Customer>();

        [Given(@"(.*) is a registered customer")]
        public void GivenARegisteredCustomer(string customerName)
        {
            customers[customerName] = new Customer {Name = customerName};
        }
        
        [Given(@"(.*) is an available driver")]
        public void GivenAnAvailableDriver(string driverName)
        {
            drivers[driverName] = new Driver {Name = driverName};
        }
            
        [When(@"(.*) books a ride with (.*)")]
        public void WhenCustomerBooksARide(string customerName, string driverName)
        {
            booking = new Booking {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            };
        }
        
        [Then(@"(.*) is booked to (.*)")]
        public void ThenDriverIsBookedToCustomer(string driverName, string customerName)
        {
            Assert.AreEqual(customers[customerName], booking.Customer);
            Assert.AreEqual(drivers[driverName], booking.Driver);
        }
    }
}
