using System;
using System.Collections.Generic;
using System.Linq;
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

        public Customer[] getCustomersForRSVP(int eventID) 
        {
            Customer[] custArr = new Customer[numRSVP];

            int k = 1;
            for (int i = 0; i < numRSVP; i++) 
            {
                if (rsvpList[i].getEvent().getEventId() == eventID) { k++; }
            }

            Customer[] answer = new Customer[k];

            k = 0;
            for (int i = 0; i < numRSVP; i++)
            {
                if (rsvpList[i].getEvent().getEventId() == eventID)  { answer[k++] = rsvpList[i].getCustomer(); }
            }


            return answer;
        }
    }
}
