using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace TheProject.Test.Features
{
    [Binding]
    public class BookARideSteps
    {
        // ReSharper disable once InconsistentNaming
        private readonly LuberContext LuberContext = new LuberContext();

        [Given(@"(.*) is a registered customer")]
        public void GivenARegisteredCustomer(string name)
        {
            LuberContext.AddCustomer(name);
        }

        [Given(@"(.*) is an available driver")]
        public void GivenAnAvailableDriver(string driverName)
        {
            LuberContext.AddDriver(driverName);
        }

        [When(@"(.*) books a ride with (.*)")]
        public void WhenCustomerBooksARide(string customerName, string driverName)
        {
            LuberContext.CreateBooking(customerName, driverName);
        }

        [Then(@"these are the bookings")]
        public void ThenTheseAreTheBookings(Table table)
        {
            IList<BookingItem> bookingList = new List<BookingItem>();

            foreach (var booking in LuberContext.Bookings)
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
