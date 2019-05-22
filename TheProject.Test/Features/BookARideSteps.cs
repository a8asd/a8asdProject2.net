using System.Collections.Generic;
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
            _luberContext.CreateCustomer(customerName);
        }

        [Given(@"(.*) is an available driver")]
        public void GivenAnAvailableDriver(string driverName)
        {
            _luberContext.CreateDriver(driverName);
        }

        [When(@"(.*) books a ride with (.*)")]
        public void WhenCustomerBooksARide(string customerName, string driverName)
        {
            _luberContext.BookRide(customerName, driverName);
        }

        [Then(@"these are the bookings")]
        public void ThenTheseAreTheBookings(Table table)
        {
            IList<BookingItem> bookingList = new List<BookingItem>();

            foreach (var booking in _luberContext.bookings)
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
}
