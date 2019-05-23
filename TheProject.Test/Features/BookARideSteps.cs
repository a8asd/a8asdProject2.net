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

        [Given(@"TargetRadius is (.*)")]
        public void GivenTargetRadiusIs(int targetRadius)
        {
            _luberContext.TargetRadius = targetRadius;
        }

        [Given(@"(.*) is a registered customer")]
        public void GivenARegisteredCustomer(string customerName)
        {
            _luberContext.AddCustomer(customerName);
        }

        [Given(@"(.*) is an available driver at (.*), (.*)")]
        public void GivenIsAnAvailableDriverAt(string driverName, int x, int y)
        {
            _luberContext.AddDriver(driverName, x, y);
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

        [When(@"(.*) requests offers from (.*), (.*)")]
        public void WhenPatRequestsOffersFrom(string customerName, int x, int y)
        {
            _luberContext.RequestOffers(x, y);
        }

        [Then(@"these are the offers")]
        public void ThenTheseAreTheOffers(Table table)
        {
            Assert.IsTrue(_luberContext.Offers.Any());

            List<DriverItem> driverList = new List<DriverItem>();
            foreach (var offer in _luberContext.Offers)
            {
                driverList.Add(new DriverItem {
                    Driver = offer.Driver.Name,
                    Distance = offer.Distance
                });
            }

            table.CompareToSet(driverList);
        }
    }

    internal class DriverItem
    {
        public string Driver { get;  set; }
        public object Distance { get; set; }
    }

    internal class BookingItem
    {
        public string Customer { get; internal set; }
        public string Driver { get; internal set; }
    }
}
