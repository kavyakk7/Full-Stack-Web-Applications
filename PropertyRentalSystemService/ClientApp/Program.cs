using System;

namespace ClientApp
{
    class Program
    {
        // this method checks if the string value is Y/y/N/n
        public static int checkBoolean(string value)
        {
            if (value.Equals("Y") || value.Equals("y"))
            {
                return 1;
            }
            else if (value.Equals("N") || value.Equals("n"))
            {
                return 0;
            }
            else
                return -1;
        }
        // this method shows the menu to the user
        public void menu(PropertyRentalSystemProxy client)
        {
            PropertyRentalSystemProxy myclient = client;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine(" => Property Search : Choose what you want to do...");
            Console.WriteLine(" (1) Search for property by postal code ");
            Console.WriteLine(" (2) Enter a new property ");
            Console.WriteLine(" (3) Get a list of all properties ");
            Console.WriteLine(" (4) Exit program ");
            Console.WriteLine("----------------------------------------------------");
            Console.Write(" => Enter your choice : ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    {
                        // Get the postal code user wants to search for and 
                        // search and show in the database 'property'
                        Console.WriteLine("Enter the postal code: ");
                        string postalcode = Console.ReadLine();
                        client.setPostalCode(postalcode);
                        string data = myclient.selectFromTableUsingPostalCode();
                        Console.WriteLine(data);
                        // display menu again
                        menu(client);
                        break;
                    }
                case "2":
                    {
                        // Get the inputs from the user and
                        // insert into the database 'property'
                        string address;
                        string postalCode;
                        string cS;
                        bool currentStatus = false;
                        string leaseEndDate;
                        string sA;
                        bool studentsAllowed = false;
                        string mOA;
                        bool multipleOccupantsAllowed = false;
                        int noOfOccupantsAllowed = 1;
                        string pA;
                        bool petsAllowed = false;
                        string cA;
                        bool childrenAllowed = false;
                        Console.WriteLine("Enter the details of the new property \n");
                        Console.Write("Enter the address of the property :");
                        address = Console.ReadLine();
                        Console.Write("Enter the postal code of the area :");
                        postalCode = Console.ReadLine();
                        Console.Write("Is the property available (Enter Y/y for YES and N/n for NO) : ");
                        cS = Console.ReadLine();
                        currentStatus = (checkBoolean(cS) == 1) ? true : false;
                        Console.Write("Enter the lease end date if applicable : ");
                        leaseEndDate = Console.ReadLine();
                        Console.Write("Are students allowed in the property (Enter Y/y for YES and N/n for NO) : ");
                        sA = Console.ReadLine();
                        studentsAllowed = (checkBoolean(sA) == 1) ? true : false;
                        if (studentsAllowed)
                        {
                            Console.Write("Are multiple occupants allowed in the property (Enter Y/y for YES and N/n for NO) : ");
                            mOA = Console.ReadLine();
                            multipleOccupantsAllowed = (checkBoolean(mOA) == 1) ? true : false;
                            if (multipleOccupantsAllowed)
                            {
                                Console.Write("How many multiple occupants are allowed in the property : ");
                                noOfOccupantsAllowed = Console.Read();
                            }
                        }
                        else
                        {
                            Console.Write("Are pets allowed in the property (Enter Y/y for YES and N/n for NO) : ");
                            pA = Console.ReadLine();
                            petsAllowed = (checkBoolean(pA) == 1) ? true : false;
                            Console.Write("Are children allowed in the property (Enter Y/y for YES and N/n for NO) : ");
                            cA = Console.ReadLine();
                            childrenAllowed = (checkBoolean(cA) == 1) ? true : false;
                        }
                        client.setAddress(address);
                        client.setPostalCode(postalCode);
                        client.setCurrentStatus(currentStatus);
                        client.setLeaseEndDate(leaseEndDate);
                        client.setStudentsAllowed(studentsAllowed);
                        client.setMultipleOccupantsAllowed(multipleOccupantsAllowed);
                        client.setNoOfOccupantsAllowed(noOfOccupantsAllowed);
                        client.setPetsAllowed(petsAllowed);
                        client.setChildrenAllowed(childrenAllowed);
                        bool insertCheck = myclient.insertIntoTable();
                        if (insertCheck)
                            Console.WriteLine("Inserted into the table property and lettings successfully!");
                        // display menu again
                        menu(client);
                        break;
                    }
                case "3":
                    {
                        // search and show in the database 'property'
                        // of all available properties for students
                        string data = myclient.selectFromTableForAvailableProperty();
                        Console.WriteLine(data);
                        menu(client);
                        break;
                    }
                case "4":
                    {
                        // exit code
                        Console.WriteLine("Press any key to exit!");
                        Console.ReadKey();
                        break;
                    }
                default:
                    {
                        // invalid value
                        Console.WriteLine("Invalid choice! Please enter 1, 2, 3 or 4!");
                        menu(client);
                        break;
                    }
            }         
        }
        public static void Main(string[] args)
        {
            // Create objects for Program and PropertyRentalSystemProxy
            Program pgm = new Program();
            PropertyRentalSystemProxy myclient = new PropertyRentalSystemProxy();
            pgm.menu(myclient);
        }
    }
}