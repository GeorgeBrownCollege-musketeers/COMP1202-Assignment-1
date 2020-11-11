using System;
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class RSVPManager
    {
        private static int currentRSVPNumber;
        private int maxNumRSVP;
        private int numRSVP;
        private RSVP[] rsvpList;

        public RSVPManager(int crn, int max)
        {
            currentRSVPNumber = crn;
            this.maxNumRSVP = max;
            this.numRSVP = 0;
            this.rsvpList = new RSVP[maxNumRSVP];
        }

        public bool addRSVP(Event eve, Customer cus)
        {
            if (numRSVP >= maxNumRSVP) { return false; }
            string date = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");

            RSVP r = new RSVP(currentRSVPNumber, date, eve, cus);
            currentRSVPNumber++;
            rsvpList[numRSVP] = r;
            numRSVP++;
            return true;
        }

        public bool RSVPExist(int rid)
        {
            int loc = findRSVP(rid);
            if (loc == -1) { return false; }
            return true;
        }

        public int findRSVP(int rid)
        {
            for (int x = 0; x < numRSVP; x++)
            {
                if (rsvpList[x].getId() == rid)
                    return x;
            }
            return -1;
        }

        public RSVP getRSVP(int rid)
        {
            int loc = findRSVP(rid);
            if (loc == -1) { return null; }
            return rsvpList[loc];
        }

        public string getRSVPInfo(int rid)
        {
            int loc = findRSVP(rid);
            if (loc == -1) { return "There is no RSVP with id " + rid + "."; }
            return rsvpList[loc].ToString();
        }

        public string getRSVPList()
        {
            string s = "RSVP List:";
            s = s + "\nNumber \t Date \t\t\t Name \t\t Event ID";
            for (int x = 0; x < numRSVP; x++)
            {
                s = s + "\n" + rsvpList[x].getId() + "\t" + rsvpList[x].getDate() +"\t"+rsvpList[x].getCustomer().getFirstName() + " " + rsvpList[x].getCustomer().getLastName() + "\t" + rsvpList[x].getEvent().getEventId();
            }
            return s;
        }
    }
}
