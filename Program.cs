namespace SkeletonFinalApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Creating login Menu for Final Project
            Console.WriteLine("*********Welcome To The Banking App*********");
            Console.WriteLine("********************************************");
            Console.WriteLine();

            //Displays Menu to user 
            Console.WriteLine("Choose from the Menu ");
            Console.WriteLine("1.  Admin Login: ");
            Console.WriteLine("2.  Customer Login: ");
            Console.WriteLine("3.  Register new Customer: ");
            Console.WriteLine("99. Exit Application: ");
            

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    //Goes to Admin login requiring a username and password
                    //Both need to be in asterisk form for privacy
                    //Will be a Methods
                    break;
                case 2:
                    //Same as Admin but a Customer version
                    //Same with password and username criteria
                    //Will be Methods aswell
                    break;
                case 3:
                    //Registering a new Customer
                    //Asking for username and password creation
                    //Methods as well
                    break;
                case 99:
                    Console.WriteLine("Exiting Application ");
                    Environment.Exit(0);
                        break;
                default:
                    Console.WriteLine("Invalid input. Attempts (Display how many attempts left) ");
                    break;

            }//End of Switch






        }//End of Method Main
    }//End of Class program
}//End of Namespace
