/*
 * Fatih Camgoz 101 266 304
 * Simon Bermudez 101 250 449
 * Oliver Kmiec 101 247 765
 * Rahul Singla 101 229 794
*/

using System;

namespace COMP1202_Assignment_1
{
    class Program
    {
        static EventCoordinator eCoord;

        public static void deleteCustomer()
        {
            int id;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to delete:");
            id = getIntChoice();
            if (eCoord.deleteCustomer(id))
            {
                Console.WriteLine("Customer with id {0} deleted..", id);
            }
            else
            {
                Console.WriteLine("Customer with id {0} was not found..", id);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewCustomers()
        {
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificCustomer()
        {
            int id;
            string cust;
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.Write("Please enter a customer id to View:");
            id = getIntChoice();
            Console.Clear();
            cust = eCoord.getCustomerInfoById(id);
            Console.WriteLine(cust);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void addCustomer()
        {
            string fname, lname, phone;

            Console.Clear();
            Console.WriteLine("-----------Add Customer----------");
            Console.Write("Please enter the customer's first name:");
            fname = Console.ReadLine();
            Console.Write("Please enter the customer's last name:");
            lname = Console.ReadLine();
            Console.Write("Please enter the customer's phone:");
            phone = Console.ReadLine();
            if (eCoord.addCustomer(fname, lname, phone))
            {
                Console.WriteLine("Customer successfully added..");
            }
            else
            {
                Console.WriteLine("Customer was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void addEvent()
        {
            string eventName, venue;
            Date eventDate;
            int maxAttendees;
            int day, month, year, hour, minute;

            Console.Clear();
            Console.WriteLine("-----------Add Event----------");
            Console.Write("Please enter the name of the Event:");
            eventName = Console.ReadLine();
            Console.Write("Please enter venue for the event:");
            venue = Console.ReadLine();
            Console.Write("Please enter the Day of the event:");
            day = getIntChoice();
            Console.Write("Please enter the Month of the event (as an integer):");
            month = getIntChoice();
            Console.Write("Please enter the Year of the event:");
            year = getIntChoice();
            Console.Write("Please enter the Hour the event starts in 24 hour format:");
            hour = getIntChoice();
            Console.Write("Please enter the Minute the event starts:");
            minute = getIntChoice();
            eventDate = new Date(day, month, year, hour, minute);
            Console.Write("Please enter the maximum number of attendees:");
            maxAttendees = getIntChoice();
            if (eCoord.addEvent(eventName, venue, eventDate, maxAttendees))
            {
                Console.WriteLine("Event successfully added..");
            }
            else
            {
                Console.WriteLine("The event was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewEvents()
        {
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificEvent()
        {
            int id;
            string ev;
            Console.Clear();
            Console.WriteLine(eCoord.eventList());
            Console.Write("Please enter an event id to View:");
            id = getIntChoice();
            Console.Clear();
            ev = eCoord.getEventInfoById(id);
            Console.WriteLine(ev);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void addRSVP()
        {
            Console.Clear();
            Console.WriteLine(eCoord.customerList());
            Console.WriteLine("\n");
            Console.WriteLine(eCoord.eventList());

            int eventId, custId;

            Console.WriteLine("-----------Add RSVP----------");
            while (true)
            {
                Console.Write("Please enter the Event ID of the event:");
                eventId = getIntChoice();
                if (eCoord.isValidEvent(eventId)){ break; }
                else{ Console.WriteLine("Please choose valid event");}
            }

            while (true)
            {
                Console.Write("Please enter the Customer ID of the customer:");
                custId = getIntChoice();
                if (eCoord.isValidCustomer(custId)) { break; }
                else { Console.WriteLine("Please choose valid customer"); }
            }

            if (eCoord.addRSVP(eventId, custId))
            {
                Console.WriteLine("RSVP successfully added..");
            }
            else
            {
                Console.WriteLine("The RSVP was not added..");
            }

            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void viewRSVP()
        {
            Console.Clear();
            Console.WriteLine(eCoord.rsvpList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static string customerMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Customer Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Customer \n";
            s += "2: View Customers \n";
            s += "3: View Customer Details \n";
            s += "4: Delete Customer\n";
            s += "5: Return to the main menu.";
            return s;
        }

        public static string eventMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Event Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Event \n";
            s += "2: View all Events \n";
            s += "3: View Event Details \n";
            s += "4: Return to the main menu.";
            return s;
        }

        public static string registrationMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Event Registration Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: RSVP for event \n";
            s += "2: View RSVPs \n";
            s += "3: Return to the main menu.";
            return s;
        }

        public static string mainMenu()
        {
            string s = "Andrew's Event Management Limited.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Customer Options \n";
            s += "2: Event Options \n";
            s += "3: RSVP for Event \n";
            s += "4: Exit";
            return s;
        }


        public static void runCustomerMenu()
        {
            string menu = customerMenu();
            int choice = getValidChoice(5, menu);
            while (choice != 5)
            {
                if (choice == 1) { addCustomer(); }
                if (choice == 2) { viewCustomers(); }
                if (choice == 3) { viewSpecificCustomer(); }
                if (choice == 4) { deleteCustomer(); }
                choice = getValidChoice(5, menu);
            }
        }

        public static void runEventMenu()
        {
            string menu = eventMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { addEvent(); }
                if (choice == 2) { viewEvents(); }
                if (choice == 3) { viewSpecificEvent(); }

                choice = getValidChoice(4, menu);
            }
        }

        public static void runRegistrationMenu()
        {
            string menu = registrationMenu();
            int choice = getValidChoice(3, menu);
            while (choice != 3)
            {
                if (choice == 1) { addRSVP(); }
                if (choice == 2) { viewRSVP(); }

                choice = getValidChoice(3, menu);
            }
        }


        public static int getValidChoice(int max, string menu)
        {
            int choice;
            Console.Clear();
            Console.WriteLine(menu);
            while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > max))
            {
                Console.Clear();
                Console.WriteLine(menu);
                Console.WriteLine("Please enter a valid choice:");
            }
            return choice;
        }

        public static int getIntChoice()
        {
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Please enter an integer:");
            }
            return choice;
        }


        public static void runProgram()
        {
            string menu = mainMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 4)
            {
                if (choice == 1) { runCustomerMenu(); }
                if (choice == 2) { runEventMenu(); }
                if (choice == 3) { runRegistrationMenu(); }

                choice = getValidChoice(4, menu);
            }
        }

        static void Main(string[] args)
        {
            eCoord = new EventCoordinator(200, 1000, 101, 5000);
            
            eCoord.addCustomer("Simon", "Bermudez", "123456789");
            eCoord.addCustomer("Fatih", "Camgoz", "123456789");
            eCoord.addCustomer("Oliver", "Kmiec", "123456789");

            eCoord.addEvent("Test", "1", new Date(1, 1, 1, 1, 1), 10);

            eCoord.addRSVP(200,101);
            eCoord.addRSVP(200, 102);

            runProgram();
            Console.WriteLine("Thank you for using Andrew's Event Management Limited System. ");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
