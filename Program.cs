using System.Diagnostics.Metrics;

namespace SkeletonFinalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating an instance of the BankingService class to access its methods and properties
            BankingService bankingService = new BankingService();


            //Default admin login details below
            //Username: admin
            //Password: admin123
            Admin admin = new Admin("Admin", "admin", "admin123", bankingService._customers);


            //Creating a boolean and a do while loop to keep the menu running until the user decides to exit
            bool isRunning = true;
            int invalidAttemptsLeft = 3; // Set the number of allowed invalid attempts

            //The menu will be displayed until the user chooses to exit or runs out of invalid attempts
            do
            {
                try
                {
                    //Creating login Menu for Final Project
                    Console.WriteLine("*********Welcome To The Banking App*********");
                    Console.WriteLine("********************************************");
                    Console.WriteLine();

                    //Displays Menu to user 
                    Console.WriteLine("Choose from the Menu ");
                    Console.WriteLine("1.  Admin Login: ");
                    Console.WriteLine("2.  Customer Login: ");
                    Console.WriteLine("99. Exit Application: ");

                    //Reads user input and checks if it's a valid integer. If not, it decrements the invalid attempts and prompts the user again
                    if (!int.TryParse(Console.ReadLine(), out int choice))
                    {
                        invalidAttemptsLeft--;
                        Console.WriteLine($"Please enter a valid number. Attempts left: {invalidAttemptsLeft}");

                        if (invalidAttemptsLeft <= 0)
                        {
                            Console.WriteLine("Too many invalid attempts. Exiting Application.");
                            isRunning = false;
                        }
                        continue; // Skip the rest of the loop and prompt again
                    }

                    switch (choice)
                    {
                        case 1:
                            //Goes to Admin login requiring a username and password
                            //Both need to be in asterisk form for privacy
                            Console.WriteLine("Enter Admin Username: ");
                            string adminUser = Console.ReadLine()?.Trim() ?? string.Empty;

                            //Using the ReadMaskedInput method from the BankingService class to read the password input without displaying it 
                            Console.WriteLine("Enter Admin Password: ");
                            string adminPass = BankingService.ReadMaskedInput();

                            //Checks if the username and password are not empty or whitespace. If they are, it decrements the invalid attempts and prompts the user again
                            if (string.IsNullOrWhiteSpace(adminUser) || string.IsNullOrWhiteSpace(adminPass))
                            {
                                invalidAttemptsLeft--;
                                Console.WriteLine($"Admin username and password are required. Attempts left: {invalidAttemptsLeft}");
                                break;
                            }

                            //Verifies the admin credentials using the VerifyPassword method from the Admin class. 
                            //If the credentials are correct, it shows the admin menu. If not, it decrements the invalid attempts and prompts the user again
                            if (admin.UserName.Equals(adminUser, StringComparison.OrdinalIgnoreCase) && admin.VerifyPassword(adminPass))
                            {
                                Console.WriteLine("Admin login successful!");
                                invalidAttemptsLeft = 3;
                                admin.ShowAdminMenu();
                            }
                            else
                            {
                                invalidAttemptsLeft--;
                                Console.WriteLine($"Invalid admin credentials. Attempts left: {invalidAttemptsLeft}");
                            }
                            break;
                        case 2:
                            //Same as Admin but a Customer version
                            //Same with password and username criteria
                            if (!bankingService.HandleCustomerLogin())
                            {
                                invalidAttemptsLeft = 3;
                            }
                            else
                            {
                                invalidAttemptsLeft--;
                                Console.WriteLine($"Customer login failed. Attempts left: {invalidAttemptsLeft}");  
                            }
                            break;
                        case 99:
                            isRunning = false;
                            Console.WriteLine("Exiting Application ");
                            break;
                        default:
                            invalidAttemptsLeft--;
                            Console.WriteLine($"Invalid input. Attempts left: {invalidAttemptsLeft}");
                            break;
                    }//End of Switch

                    //Checks if the user has run out of invalid attempts and exits the application if they have
                    if (invalidAttemptsLeft <= 0 && isRunning)
                    {
                        Console.WriteLine("Too many invalid attempts. Exiting Application.");
                        isRunning = false;
                    }
                }
                //Catches any unexpected exceptions that may occur during the execution of the application and displays an error message to the user
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected application error: {ex.Message}");
                }

            } while (isRunning);//end of Do While Loop





        }//End of Method Main
    }//End of Class program
}//End of Namespace
