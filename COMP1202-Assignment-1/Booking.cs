using System;
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class Booking
    {
        private string date;
        private int id;
        private Flight flight;
        private Customer cus;

        public Booking(int id, string date, Flight flight, Customer cus)
        {
            this.id = id;
            this.date = date;
            this.flight = flight;
            this.cus = cus;
        }

        public int getId() { return this.id; }
        public string getDate() { return this.date; }
        public Flight getFlight() { return this.flight; }
        public Customer getCustomer() { return this.cus; }
        public override string ToString()
        {
            int flightId = flight.getFlightId();
            string customerName = cus.getFirstName() + " " + cus.getLastName();
            string s = "Booking Id:" + this.id;
            s += "\nDate" + this.date;
            s += "\nCustomer Name" + customerName;
            s += "\nFlight Id:" + flightId;
            return s;
        }
    }
}
