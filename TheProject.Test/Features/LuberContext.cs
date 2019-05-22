using System.Collections.Generic;

namespace TheProject.Test.Features
{
    public class LuberContext
    {
        public IList<Booking> Bookings = new List<Booking>();
        private readonly Dictionary<string, Customer> Customers = new Dictionary<string, Customer>();
        private readonly Dictionary<string, Driver> Drivers = new Dictionary<string, Driver>();

        public void AddCustomer(string name)
        {
            Customers[name] = new Customer {Name = name};
        }

        public void AddDriver(string driverName)
        {
            Drivers[driverName] = new Driver {Name = driverName};
        }

        public void CreateBooking(string customerName, string driverName)
        {
            Bookings.Add(new Booking
            {
                Customer = Customers[customerName],
                Driver = Drivers[driverName]
            });
        }
    }
}