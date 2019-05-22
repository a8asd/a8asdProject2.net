using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookARideSteps
    {
        private IList<Booking> bookings = new List<Booking>();
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
            bookings.Add(new Booking {
                Customer = customers[customerName],
                Driver = drivers[driverName]
            });
        }

        [Then(@"these are the bookings")]
        public void ThenTheseAreTheBookings(Table table)
        {
            IList<BookingItem> bookingList = new List<BookingItem>();

            foreach (var booking in bookings)
            {
                bookingList.Add(new BookingItem{
                    Customer = booking.Customer.Name,
                    Driver = booking.Driver.Name
                });
            }

            table.CompareToSet(bookingList);
        }
    }

    internal class BookingItem
    {
        public string Customer { get; internal set; }
        public string Driver { get; internal set; }
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
