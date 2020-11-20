﻿using System; 
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class FlightManager
    {
        private static int currentFlightId;
        private int maxFlights;
        private int numFlights;
        private Flight[] flightList;

        public FlightManager(int idSeed, int max)
        {
            currentFlightId = idSeed;
            maxFlights = max;
            numFlights = 0;
            flightList = new Flight[maxFlights];
        }

        public string addFlight(int fid, string name, string venue, Date flightDate, int maxPassengers)
        {
            String s = "";
            if (numFlights > maxFlights && flightExists(fid) == false)
            {
                s = "Number of flights cannot be more than max flights and flight is already exist";
                return s;
            }
            else if (numFlights > maxFlights && flightExists(fid) == true) {
                s = "Number of flights number cannot be more than maximum flights!";
                return s;
            }
            else if(numFlights < maxFlights && flightExists(fid) == false)
            {
                s = "Flight is not exist";
                return s;
            }
            Flight e = new Flight(fid, name, venue, flightDate, maxPassengers);
            flightList[numFlights] = e;
            numFlights++;
            currentFlightId++;
            s = $"Flight {name} with id of {fid} is successfully been added";
            return s;
        }

        private int findFlight(int fid)
        {
            for (int x = 0; x < numFlights; x++)
            {
                if (flightList[x].getFlightId() == fid)
                    return x;
            }
            return -1;
        }

        public bool flightExists(int fid)
        {
            int loc = findFlight(fid);
            if (loc == -1) { return false; }
            return true;
        }
        
        public Flight getFlight(int fid)
        {
            int loc = findFlight(fid);
            if (loc == -1) { return null; }
            return flightList[loc];
        }

        public bool deleteFlight(int fid)
        {
            int loc = findFlight(fid);
            if (loc == -1) { return false; }
            flightList[loc] = flightList[numFlights - 1];
            numFlights--;
            return true;
        }
        public string getFlightInfo(int fid)
        {
            int loc = findFlight(fid);
            if (loc == -1) { return "There is no flight with id " + fid + "."; }
            return flightList[loc].ToString();
        }
        public string getFlightList()
        {
            string s = "Flight List:";
            for (int x = 0; x < numFlights; x++)
            {
                s = s + "\n" + flightList[x].getFlightId() + " \t " + flightList[x].getFlightName() + " \t " + flightList[x].getVenue();
            }
            return s;
        }

    }

}