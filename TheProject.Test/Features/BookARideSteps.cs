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
        private readonly LuberContext _luberContext = new LuberContext();

        [Given(@"(.*) is a registered customer")]
        public void GivenARegisteredCustomer(string customerName)
        {
            _luberContext.AddCustomer(customerName);
        }

        [Given(@"(.*) is an available driver")]
        public void GivenAnAvailableDriver(string driverName)
        {
            _luberContext.AddDriver(driverName);
        }

        [When(@"(.*) books a ride with (.*)")]
        public void WhenCustomerBooksARide(string customerName, string driverName)
        {
            _luberContext.CreateBooking(customerName, driverName);
        }

        [Then(@"these are the bookings")]
        public void ThenTheseAreTheBookings(Table table)
        {
            IList<BookingItem> bookingList = new List<BookingItem>();

            foreach (var booking in _luberContext.Bookings)
            {
                bookingList.Add(new BookingItem{
                    Customer = booking.Customer.Name,
                    Driver = booking.Driver.Name
                });
            }

            table.CompareToSet(bookingList);
        }

        [When(@"Pat requests offers")]
        public void WhenPatRequestsOffers()
        {
            _luberContext.RequestOffers();
        }

        [Then(@"these are the offers")]
        public void ThenTheseAreTheOffers(Table table)
        {
            Assert.IsTrue(_luberContext.Offers.Any());

            List<DriverItem> driverList = new List<DriverItem>();
            for(int i =0; i < _luberContext.Offers.Count; i++) { 
                driverList.Add(new DriverItem {
                    Driver = _luberContext.Offers[i].Name
                });
            }

            table.CompareToSet(driverList);
        }
    }

    internal class DriverItem
    {
        public string Driver { get;  set; }
    }

    internal class BookingItem
    {
        public string Customer { get; internal set; }
        public string Driver { get; internal set; }
    }
}
