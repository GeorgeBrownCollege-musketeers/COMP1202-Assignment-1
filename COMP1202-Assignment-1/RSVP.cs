using System;
using System.Collections.Generic;
using System.Text;

namespace COMP1202_Assignment_1
{
    class RSVP
    {
        private string date;
        private int id;
        private Event eve;
        private Customer cus;

        public RSVP(int id, string date, Event eve, Customer cus)
        {
            this.id = id;
            this.date = date;
            this.eve = eve;
            this.cus = cus;
        }

        public int getId() { return this.id; }
        public string getDate() { return this.date; }
        public Event getEvent() { return this.eve; }
        public Customer getCustomer() { return this.cus; }
        public override string ToString()
        {
            int eventId = eve.getEventId();
            string customerName = cus.getFirstName() + " " + cus.getLastName();
            string s = "RSVP Id:" + this.id;
            s += "\nDate" + this.date;
            s += "\nCustomer Name" + customerName;
            s += "\nEvent Id:" + eventId;
            return s;
        }
    }
}
