﻿using System;
using System.Collections.Generic;

namespace TheProject.Test.Features
{
    public class LuberContext
    {
        public IList<Booking> Bookings = new List<Booking>();
        public readonly Dictionary<string, Customer> Customers = new Dictionary<string, Customer>();
        public readonly Dictionary<string, Driver> Drivers = new Dictionary<string, Driver>();
        public IList<Driver> Offers = new List<Driver>();

        public int TargetRadius { get; internal set; }

        public void AddCustomer(string name)
        {
            Customers[name] = new Customer {Name = name};
        }

        public void AddDriver(string driverName, int x, int y)
        {
            Drivers[driverName] = new Driver {Name = driverName, LocationX =x, LocationY =y};
        }

        public void CreateBooking(string customerName, string driverName)
        {
            Bookings.Add(new Booking
            {
                Customer = Customers[customerName],
                Driver = Drivers[driverName]
            });
        }

        public void RequestOffers(int x, int y)
        {
            foreach (var driver in Drivers.Values)
            {
                if (Math.Sqrt(Math.Pow((driver.LocationX - x), 2) + Math.Pow((driver.LocationY - y), 2)) <= this.TargetRadius)
                {
                    Offers.Add(driver);
                }
            }
        }
    }
}