using System;

namespace COMP1202_Assignment_1
{
    class Program
    {
        static FlightCoordinator flightCoord;

        public static void deleteCustomer()
        {
            int id;
            Console.Clear();
            Console.WriteLine(flightCoord.customerList());
            Console.Write("Please enter a customer id to delete:");
            id = getIntChoice();
            if (flightCoord.deleteCustomer(id))
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
            Console.WriteLine(flightCoord.customerList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificCustomer()
        {
            int id;
            string cust;
            Console.Clear();
            Console.WriteLine(flightCoord.customerList());
            Console.Write("Please enter a customer id to View:");
            id = getIntChoice();
            Console.Clear();
            cust = flightCoord.getCustomerInfoById(id);
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
            if (flightCoord.addCustomer(fname, lname, phone))
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

        public static void addFlight()
        {
            string flightName, venue;
            Date flightDate;
            int maxPassengers;
            int day, month, year, hour, minute;

            Console.Clear();
            Console.WriteLine("-----------Add Flights----------");
            Console.Write("Please enter the name of the Flight:");
            flightName = Console.ReadLine();
            Console.Write("Please enter venue for the flight:");
            venue = Console.ReadLine();
            Console.Write("Please enter the Day of the flight:");
            day = getIntChoice();
            Console.Write("Please enter the Month of the flight (as an integer):");
            month = getIntChoice();
            Console.Write("Please enter the Year of the flight:");
            year = getIntChoice();
            Console.Write("Please enter the Hour the flight starts in 24 hour format:");
            hour = getIntChoice();
            Console.Write("Please enter the Minute the flight starts:");
            minute = getIntChoice();
            flightDate = new Date(day, month, year, hour, minute);
            Console.Write("Please enter the maximum number of passengers:");
            maxPassengers = getIntChoice();
            if (flightCoord.addFlight(flightName, venue, flightDate, maxPassengers))
            {
                Console.WriteLine("Flight successfully added..");
            }
            else
            {
                Console.WriteLine("The flight was not added..");
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }


        public static void viewFlights()
        {
            Console.Clear();
            Console.WriteLine(flightCoord.flightList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void viewSpecificFlight()
        {
            int id;
            string ev;
            Console.Clear();
            Console.WriteLine(flightCoord.flightList());
            Console.Write("Please enter an flight id to View:");
            id = getIntChoice();
            Console.Clear();
            ev = flightCoord.getFlightInfoById(id);
            Console.WriteLine(ev);
            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void makeBooking()
        {
            Console.Clear();
            Console.WriteLine(flightCoord.customerList());
            Console.WriteLine("\n");
            Console.WriteLine(flightCoord.flightList());

            int flightId, custId;

            Console.WriteLine("-----------Make Booking----------");
            while (true)
            {
                Console.Write("Please enter the Flight ID of the flight:");
                flightId = getIntChoice();
                if (flightCoord.isValidFlight(flightId)){ break; }
                else{ Console.WriteLine("Please choose valid flight");}
            }

            while (true)
            {
                Console.Write("Please enter the Customer ID of the customer:");
                custId = getIntChoice();
                if (flightCoord.isValidCustomer(custId)) { break; }
                else { Console.WriteLine("Please choose valid customer"); }
            }

            if (flightCoord.addBooking(flightId, custId))
            {
                Console.WriteLine("Booking successfully added..");
            }
            else
            {
                Console.WriteLine("The Booking was not added..");
            }

            Console.WriteLine("\nPress any key to continue return to the previous menu.");
            Console.ReadKey();
        }

        public static void viewBooking()
        {
            Console.Clear();
            Console.WriteLine(flightCoord.bookingList());
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static string customerMenu()
        {
            string s = "Air Musketeers Limited.\n";
            s += "Customer Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Customer \n";
            s += "2: View Customers \n";
            s += "3: Delete Customer\n";
            s += "4: Return to the main menu.";
            return s;
        }

        public static string flightMenu()
        {
            string s = "Air Musketeers Limited.\n";
            s += "Flight Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Add Flight  \n"; //Add Event
            s += "2: View all Flights \n"; //View all Events
            s += "3: View A Particular Flight \n"; //View Event Details
            s += "4: Delete Flight \n";
            s += "5: Return to the main menu.";
            return s;
        }

        public static string bookingMenu()
        {
            string s = "Air Musketeers Limited.\n";
            s += "Bookings Menu.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Make Booking \n";
            s += "2: View Bookings \n";
            s += "3: Return to the main menu.";
            return s;
        }

        public static string mainMenu()
        {
            string s = "Air Musketeers Limited.\n";
            s += "Please select a choice from the menu below:\n";
            s += "1: Customers \n";
            s += "2: Flights \n"; //Event Options
            s += "3: Bookings \n"; //RSVP for Event
            s += "4: Exit";
            return s;
        }


        public static void runCustomerMenu()
        {
            string menu = customerMenu();
            int choice = getValidChoice(5, menu);
            while (choice != 4)
            {
                if (choice == 1) { addCustomer(); }
                if (choice == 2) { viewCustomers(); }
                if (choice == 3) { deleteCustomer(); }
                choice = getValidChoice(4, menu);
            }
        }

        public static void runFlightMenu()
        {
            string menu = flightMenu();
            int choice = getValidChoice(4, menu);
            while (choice != 5)
            {
                if (choice == 1) { addFlight(); }
                if (choice == 2) { viewFlights(); }
                if (choice == 3) { viewSpecificFlight(); }
                if (choice == 4) { deleteFlight(); }

                choice = getValidChoice(5, menu);
            }
        }

        private static void deleteFlight()
        {
            int id;
            Console.Clear();
            Console.WriteLine(flightCoord.flightList());
            Console.Write("Please enter a flight id to delete:");
            id = getIntChoice();
            if (flightCoord.deleteFlight(id))
            {
                Console.WriteLine("Flight with id {0} deleted..", id);
            }
            else
            {
                Console.WriteLine("Flight with id {0} was not found..", id);
            }
            Console.WriteLine("\nPress any key to continue return to the main menu.");
            Console.ReadKey();
        }

        public static void runBookingMenu()
        {
            string menu = bookingMenu();
            int choice = getValidChoice(3, menu);
            while (choice != 3)
            {
                if (choice == 1) { makeBooking(); }
                if (choice == 2) { viewBooking(); }

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
                if (choice == 2) { runFlightMenu(); }
                if (choice == 3) { runBookingMenu(); }

                choice = getValidChoice(4, menu);
            }
        }

        static void Main(string[] args)
        {
            flightCoord = new FlightCoordinator(200, 1000, 101, 5000);
            runProgram();
            Console.WriteLine("Thank you for using Air Musketeers Limited System. ");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

    }
}
