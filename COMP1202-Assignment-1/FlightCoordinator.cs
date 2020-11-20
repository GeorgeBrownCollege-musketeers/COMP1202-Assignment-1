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
        public bool addCustomer(int cid, string fname, string lname, string phone)
        {
            if (custMan.customerExist(cid))
            {
                return false;
            }
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

        // Flight related methods
        public string addFlight(int fid, string name, string venue, Date eventDate, int maxPassenger)
        {
            String s = "";
            if (flightMan.flightExists(fid))
                
            {
                s = "Flight you want to add is already exist";
                return s;
            }
            return flightMan.addFlight(fid, name, venue, eventDate, maxPassenger);
        }

        public bool deleteFlight(int fid)
        {
            if (flightMan.flightExists(fid))
            {
                flightMan.deleteFlight(fid);
                return true;
            }
            return false;
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

        //Booking related Methods
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
            String s = "";
            if (bookMan.bookingExist(id))
            {
                return bookMan.getBookingInfo(id);
            }
            s = "Booking is not exist";
            return s;
        }
    }

}
