using System;
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class Flight
    {
        private int flightId;
        private string flightName;
        private string venue;
        private Date flightDate;
        private int maxPassengers;
        private int numPassengers;
        private string dateCreated;
        private Customer[] passengerList;

        public Flight(int flightId, string name, string venue, Date eventDate, int maxPassengers)
        {
            this.flightId = flightId;
            this.flightName = name;
            this.venue = venue;
            this.flightDate = eventDate;
            this.maxPassengers = maxPassengers;
            numPassengers = 0;
            passengerList = new Customer[maxPassengers];
            dateCreated = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
        }

        public int getFlightId() { return flightId; }
        public string getFlightName() { return flightName; }
        public string getVenue() { return venue; }

        public int getMaxPassengerss() { return maxPassengers; }
        public int getNumPassengers() { return numPassengers; }

        public bool addPassenger(Customer c)
        {
            if (numPassengers >= maxPassengers) { return false; }
            passengerList[numPassengers] = c;
            numPassengers++;
            return true;
        }

        private int findPassenger(int custId)
        {
            for (int x = 0; x < maxPassengers; x++)
            {
                if (passengerList[x].getId() == custId)
                    return x;
            }
            return -1;
        }

        public bool removePassenger(int custId)
        {
            int loc = findPassenger(custId);
            if (loc == -1) return false;
            passengerList[loc] = passengerList[numPassengers - 1];
            numPassengers--;
            return true;
        }

        public string getPassengers()
        {
            string s = "\nCustomers registered :";
            for (int x = 0; x < numPassengers; x++)
            {
                s = s + "\n" + passengerList[x].getFirstName() + " " + passengerList[x].getLastName();
            }
            return s;
        }

        public override string ToString()
        {
            string s = "Event: " + flightId + "\nName: " + flightName;
            s = s + "\nVenue: " + venue;
            s = s + "\nDate:" + flightDate;
            s = s + "\nRegistered Passengers:" + numPassengers;
            s = s + "\nAvailable spaces:" + (maxPassengers - numPassengers);
            s = s + getPassengers();
            return s;
        }

    }

}
