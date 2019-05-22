using System.Collections.Generic;

namespace TheProject
{
    public class LuberContext
    {
        public IList<Booking> bookings = new List<Booking>();
        private readonly Dictionary<string, Customer> _customers = new Dictionary<string, Customer>();
        private readonly Dictionary<string, Driver> _drivers = new Dictionary<string, Driver>();

        public void CreateCustomer(string customerName)
        {
            _customers[customerName] = new Customer {Name = customerName};
        }

        public void CreateDriver(string driverName)
        {
            _drivers[driverName] = new Driver {Name = driverName};
        }

        public void BookRide(string customerName, string driverName)
        {
            bookings.Add(new Booking
            {
                Customer = _customers[customerName],
                Driver = _drivers[driverName]
            });
        }
    }
}