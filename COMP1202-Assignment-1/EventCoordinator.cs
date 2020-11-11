using System;
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class EventCoordinator
    {
        CustomerManager custMan;
        EventManager eventMan;
        RSVPManager rsvpMan;

        public EventCoordinator(int custIdSeed, int maxCust, int eventIdSeed, int maxEvents)
        {
            custMan = new CustomerManager(custIdSeed, maxCust);
            eventMan = new EventManager(eventIdSeed, maxEvents);
            rsvpMan = new RSVPManager(1, maxCust * maxEvents);
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
        public bool addEvent(string name, string venue, Date eventDate, int maxAttendee)
        {
            return eventMan.addEvent(name, venue, eventDate, maxAttendee);
        }

        public string eventList()
        {
            return eventMan.getEventList();
        }

        public string getEventInfoById(int id)
        {
            return eventMan.getEventInfo(id);
        }

        public bool isValidEvent(int id)
        {
            return eventMan.eventExists(id);
        }

        //RSVP related Methods
        public bool addRSVP(int eventId, int custId)
        {
            Event eve = eventMan.getEvent(eventId);
            Customer cus = custMan.getCustomer(custId);
            return rsvpMan.addRSVP(eve, cus);
        }

        public string rsvpList()
        {
            return rsvpMan.getRSVPList();
        }

        public string getRsvpInfoById(int id)
        {
            return rsvpMan.getRSVPInfo(id);
        }
    }

}
