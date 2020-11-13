using System;
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class FlightCoordinator
    {
        CustomerManager custMan;
        FlightManager flightMan;
        BookingManager bookMan;

        public FlightCoordinator(int custIdSeed, int maxCust, int flightIdSeed, int maxFlights)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            flightMan = new FlightManager(flightIdSeed, maxFlights);
            bookMan = new BookingManager(1, maxCust * maxFlights);
        }

        //customer related methods
        public bool addCustomer(string fname, string lname, string phone)
        {
            return custMan.addCustomer(fname, lname, phone);
        }

        public string customerList()
        {
            return custMan.getCustomerList();
        }

        public string getCustomerInfoById(int id)
        {
            return custMan.getCustomerInfo(id);
        }
        public bool deleteCustomer(int id)
        {
            return custMan.deleteCustomer(id);
        }
        public bool isValidCustomer(int id)
        {
            return custMan.customerExist(id);
        }

        // Event related methods
        public bool addFlight(string name, string venue, Date eventDate, int maxPassenger)
        {
            return flightMan.addFlight(name, venue, eventDate, maxPassenger);
        }

        public bool deleteFlight(int fid)
        {
            return flightMan.deleteFlight(fid);
        }

        public string flightList()
        {
            return flightMan.getFlightList();
        }

        public string getFlightInfoById(int id)
        {
            return flightMan.getFlightInfo(id);
        }

        public bool isValidFlight(int id)
        {
            return flightMan.flightExists(id);
        }

        //RSVP related Methods
        public bool addBooking(int flightId, int custId)
        {
            Flight flight = flightMan.getFlight(flightId);
            Customer cus = custMan.getCustomer(custId);
            return bookMan.addBooking(flight, cus);
        }

        public string bookingList()
        {
            return bookMan.getBookingList();
        }

        public string getBookingInfoById(int id)
        {
            return bookMan.getBookingInfo(id);
        }
    }

}
