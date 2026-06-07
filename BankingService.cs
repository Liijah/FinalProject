using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonFinalApp
{

    // This class will handle the business logic of the banking application,
    // such as user registration, transactions, and account management. 
    public class BankingService
    {
        //Create list of customers to store registered customers
        private List<Customer> _customers = new List<Customer>();

        //Customer login method
        public bool HandleCustomerLogin()
        {
            try
            {
                if (_customers == null || _customers.Count == 0)
                {
                    Console.WriteLine("No Customers have been registered yet. ");
                    return false;
                }

                int loginAttempts = 3; // Set a limit for login attempts


                while (loginAttempts > 0)
                {
                    //Ask user for customer's username and password
                    Console.WriteLine("Enter Username: ");

                    //Trim removes spaces from the start to the end of the string
                    //string.Empty is used to check if the input is empty or not
                    string username = Console.ReadLine()?.Trim() ?? string.Empty;

                    Console.WriteLine("Enter Password: ");
                    string password = ReadMaskedInput(); //Method to read password input without displaying it

                    //IsNullOrWhiteSpace checks if the input is null, empty, or consists only of whitespace characters
                    if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                    {
                        loginAttempts--;
                        Console.WriteLine($"Username and Password are required. Attempts left: {loginAttempts}");
                        continue; //Skip the rest of the loop and prompt again
                    }

                    //Searches for a matching Username in the Customers list
                    Customer selectedCustomer = null;

                    //Using a foreach loop to iterate through the list of customers and check if the username matches
                    foreach (Customer registeredCustomer in _customers)
                    {
                        if (registeredCustomer.UserName.Equals(username, StringComparison.OrdinalIgnoreCase))
                        {
                            selectedCustomer = registeredCustomer;
                            break;
                        }
                    }

                    //Verifies the password before allowing access
                    if (selectedCustomer != null && selectedCustomer.VerifyPassword(password))
                    {
                        Console.WriteLine($"\nWelcome, {selectedCustomer.Name}!");
                        ShowCustomerMenu(selectedCustomer); //Show customer menu after successful login
                        return true; //Login successful
                    }
                    else
                    {
                        loginAttempts--;
                        Console.WriteLine($"Invalid username or password. Attempts left: {loginAttempts}");
                    }
                }//End of while-loop


                //If login fails after max attempts, return to main menu
                Console.WriteLine($"Too many failed login attempts. Returning to main menu. ");
                return false; //Login failed after max attempts

            }//End of try block
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during Customer login: {ex.Message}");
                return false; // Return false if an exception occurs
            }
        }//End of HandleCustomerLogin method

        //Customer Menu - shown after successful Customer login
        private void ShowCustomerMenu(Customer selectedCustomer)
        {
            //Add boolean to control loop, only exit when Customer chooses to logout (option 0)
            bool customerLoggedIn = true;

            //Add counter for invalid Menu choices, if counter reaches 0, logout the Customer 
            int invalidAttempts = 3;

            //Use a do-while loop to keep showing the menu until the customer chooses to logout or exceeds invalid attempts
            do
            {
                //Display Customer Menu options
                Console.WriteLine("\n--- Customer Menu ---");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Deposit Funds");
                Console.WriteLine("3. Withdraw Funds");
                Console.WriteLine("4. Print Account Statement");
                Console.WriteLine("0. Logout");
                Console.Write("Choice: ");

                //Validate menu choice input
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    invalidAttempts--;
                    Console.WriteLine($"Invalid input. Attempts left: {invalidAttempts}");

                    //If invalid attempts reach 0, log out the customer
                    if (invalidAttempts <= 0)
                    {
                        Console.WriteLine("Too many invalid attempts. Returning to Main Menu.");
                        break; //Exit the customer menu loop
                    }

                    continue; //Prompt the menu again
                }

                //Handle the customer's menu choice using a switch statement
                switch (choice)
                {
                    case 1:
                        //Viewing the customer's account balance
                        ViewBalance(selectedCustomer);
                        break;
                    case 2:
                        //Depositing funds into the customer's account
                        Console.WriteLine("Enter deposit amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount) && depositAmount > 0)
                        {
                            Deposit(selectedCustomer, depositAmount);
                            invalidAttempts = 3; //Reset invalid attempts after a valid action

                        }
                        else
                        {
                            invalidAttempts--;
                            Console.WriteLine($"Invalid amount. Attempts left: {invalidAttempts}");
                        }
                        break;
                    case 3:
                        //Withdrawing funds from the customer's account
                        Console.WriteLine("Enter the amount you wish to withdraw: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) && withdrawAmount > 0)
                        {
                            Withdraw(selectedCustomer, withdrawAmount);
                            invalidAttempts = 3; //Reset invalid attempts after a valid action
                        }
                        else
                        {
                            invalidAttempts--;
                            Console.WriteLine($"Invalid amount. Attempts left: {invalidAttempts}");
                        }
                        break;
                    case 4:
                        //Print account statement for the Customer using the DocumentPrint Class
                        new DocumentPrint().PrintStatement(selectedCustomer);
                        invalidAttempts = 3;
                        break;
                    case 0:
                        //Logging out the customer and returning to the main menu
                        customerLoggedIn = false; //Logout
                        Console.WriteLine("Logging out...");
                        break;
                    default:
                        //Handling invalid menu choices and decrementing the invalid attempts counter
                        invalidAttempts--;
                        Console.WriteLine($"Invalid option. Attempts left: {invalidAttempts}");
                        break;

                }//End of switch statement

                //If invalid attempts reach 0, log out the customer
                if (invalidAttempts <= 0)
                {
                    Console.WriteLine("Too many invalid attempts. Returning to Main Menu.");
                    break; //Exit the customer menu loop
                }
            } while (customerLoggedIn); //End of do-while loop
        }//End of ShowCustomerMenu method

        //View Balance method - displays the current account balance for the logged-in customer
        private void ViewBalance(Customer _customer)
        {
            //Check if the customer object is not null before trying to access its properties
            if (_customer == null)
            {
                Console.WriteLine("Customer not found. Unable to view balance.");
                return;
            }

            //Display the current account balance for the customer, formatted as currency
            Console.WriteLine($"Current Balance: {_customer.AccountBalance:C}");
        }//End of ViewBalance method

        //Deposit method - allows the customer to add funds to their account balance
        public void Deposit(Customer _customer, decimal amount)
        {
            //Check if the customer object is not null before trying to access its properties
            if (_customer == null)
            {
                Console.WriteLine("Customer not found. Unable to deposit funds.");
                return;
            }

            //Validate that the deposit amount is greater than zero before adding it to the customer's account balance
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return;
            }


            _customer.Deposit(amount);
            Console.WriteLine($"Deposited {amount:C} successfully. New Balance: {_customer.AccountBalance:C}");
        }//End of Deposit method

        //Withdraw method - allows the customer to remove funds from their account balance, with checks for sufficient funds
        public void Withdraw(Customer _customer, decimal amount)
        {
            if (_customer == null)
            {
                Console.WriteLine("Customer not found. Unable to withdraw funds.");
                return;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return;
            }

            if (_customer.Withdraw(amount))
            {
                Console.WriteLine($"Withdrew {amount:C} successfully. New Balance: {_customer.AccountBalance:C}");
            }
            else
            {
                Console.WriteLine("Insufficient funds for this withdrawal.");
            }
        }//End of Withdraw method

        //Mask password input with asterisks for privacy during login
        public static string ReadMaskedInput()
        {
            //This method reads user input from the console while masking it with asterisks (*).
            string input = string.Empty;
            ConsoleKeyInfo key;

            //Use a do-while loop to read each key press until the user presses Enter
            do
            {
                key = Console.ReadKey(intercept: true); //Read key without displaying it

                if (key.Key == ConsoleKey.Backspace && input.Length > 0)
                {
                    input = input.Substring(0, input.Length - 1); //Remove last character from input
                    Console.Write("\b\b"); //Move cursor back, overwrite with space, and move back again
                }
                else if (key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Backspace)
                {
                    input += key.KeyChar; //Append the character to the input string
                    Console.Write("*"); //Display an asterisk for each character entered
                }
            } while (key.Key != ConsoleKey.Enter);

            //Move to the next line after pressing Enter
            Console.WriteLine();
            return input;
        }//End of ReadMaskedInput method
    }//End of Class BankingService
}


    