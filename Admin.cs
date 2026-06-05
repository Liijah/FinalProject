#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SkeletonFinalApp
{
    public class Admin : User  // inherits from User
    {
        // Admin specific - holds the master customer list
        private List<Customer> _customers;

        //Constructor - passes shared fields up to User
        public Admin(string name, string userName, string password, List<Customer> customers)
            : base(name, userName, password)  // calls User constructor
        {
            _customers = customers; // shared reference from BankingService
        }

        // Register a new Customer - Admin is responsible for creating new users
        public void HandleRegistration()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            Console.Write("Enter Contact: ");
            string contact = Console.ReadLine();
            Console.Write("Enter Username: ");
            string userName = Console.ReadLine();
            Console.Write("Enter Password: ");
            string password = Console.ReadLine(); // simple version for now
            // Add the new customer to the shared customer list
            Customer newCustomer = new Customer(name, id, contact, userName, password);
            _customers.Add(newCustomer);
            Console.WriteLine("Registration successful!");
        }//End of HandleRegistration method

        // Search for a customer by ID
        public Customer SearchCustomer(string customerID)
        {
            foreach (Customer c in _customers)
            {
                if (c.CustomerID == customerID) return c;
            }
            return null; // no finding return null
        }//End of SearchCustomer method

        // Delete a customer by ID
        public bool DeleteCustomer(string customerID)
        {
            Customer c = SearchCustomer(customerID);
            if (c != null)
            {
                _customers.Remove(c);
                Console.WriteLine("Customer deleted successfully.");
                return true;
            }
            Console.WriteLine("Error: Customer not found.");
            return false;
        }//End of DeleteCustomer method

        // Show Admin Menu after login
        public void ShowAdminMenu()
        {
            bool adminLoggedIn = true; // add boolean to control loop
            do
            {
                Console.WriteLine("\n--- Admin Menu ---");
                Console.WriteLine("1. Register New Customer");
                Console.WriteLine("2. Search Customer");
                Console.WriteLine("3. Delete Customer");
                Console.WriteLine("0. Logout");
                Console.Write("Choice: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            //Registering a new Customer
                            HandleRegistration();
                            break;
                        case 2:
                            //Search for a customer by ID
                            Console.Write("Enter Customer ID: ");
                            Customer found = SearchCustomer(Console.ReadLine());
                            if (found != null)
                                Console.WriteLine($"Found: {found.Name}, ID: {found.CustomerID}");
                            else
                                Console.WriteLine("Customer not found.");
                            break;
                        case 3:
                            //Delete a customer by ID
                            Console.Write("Enter Customer ID to delete: ");
                            DeleteCustomer(Console.ReadLine());
                            break;
                        case 0:
                            adminLoggedIn = false; // logout
                            Console.WriteLine("Logging out...");
                            break;
                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
            } while (adminLoggedIn);
        }//End of ShowAdminMenu method

    }//End of Class Admin
}//End of Namespace