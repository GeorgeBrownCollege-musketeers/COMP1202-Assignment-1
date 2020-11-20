using System;
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class BookingManager
    {
        private static int currentBookingNumber;
        private int maxNumBooking;
        private int numBooking;
        private Booking[] bookingList;

        public BookingManager(int cbn, int max)
        {
            currentBookingNumber = cbn;
            this.maxNumBooking = max;
            this.numBooking = 0;
            this.bookingList = new Booking[maxNumBooking];
        }

        public bool addBooking(Flight flight, Customer cus)
        {
            if (numBooking >= maxNumBooking) { return false; }
            string date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            Booking b = new Booking(currentBookingNumber, date, flight, cus);
            currentBookingNumber++;
            bookingList[numBooking] = b;
            numBooking++;
            return true;
        }

        public bool bookingExist(int bid)
        {
            int loc = findBooking(bid);
            if (loc == -1) { return false; }
            return true;
        }

        public int findBooking(int bid)
        {
            for (int x = 0; x < numBooking; x++)
            {
                if (bookingList[x].getId() == bid)
                    return x;
            }
            return -1;
        }

        public Booking getBooking(int bid)
        {
            int loc = findBooking(bid);
            if (loc == -1) { return null; }
            return bookingList[loc];
        }

        public string getBookingInfo(int bid)
        {
            int loc = findBooking(bid);
            if (loc == -1) { return "There is no Booking with id " + bid + "."; }
            return bookingList[loc].ToString();
        }

        public string getBookingList()
        {
            string s = "Booking List:";
            s = s + "\nNumber \t Date \t\t\t Name \t\t Flight ID";
            for (int x = 0; x < numBooking; x++)
            {
                s = s + "\n" + bookingList[x].getId() + "\t" + bookingList[x].getDate() +"\t"+bookingList[x].getCustomer().getFirstName() + " " + bookingList[x].getCustomer().getLastName() + "\t" + bookingList[x].getFlight().getFlightId();
            }
            return s;
        }
    }
}
