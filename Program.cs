using System;

namespace mainProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            const int minimumSignupAge = 18;
            bool IsValidInput = false;

            Console.WriteLine("Age Check: How old are you?");

            while (!IsValidInput)
            {
                Console.Write("Age: ");
                string ageInput = Console.ReadLine();

                if (int.TryParse(ageInput, out int userAge))
                {
                    if (userAge >= minimumSignupAge)
                    {
                        Console.WriteLine("\nAge check succeeded. Would you like to:");
                        Console.WriteLine("1. Create an account");
                        Console.WriteLine("2. Sign in");
                        Console.WriteLine("3. Exit");

                        bool menuChoiceValid = false;
                        while (!menuChoiceValid)
                        {
                            Console.Write("Please enter 1, 2, or 3: ");
                            string signUpOrIn = Console.ReadLine();

                            if (signUpOrIn == "1")
                            {
                                Console.WriteLine("Redirecting to signup...");
                                AccountManager.getInformation(userAge);
                                menuChoiceValid = true;
                            }
                            else if (signUpOrIn == "2")
                            {
                                Console.WriteLine("Redirecting to Login...");
                                SignIn.login();
                                menuChoiceValid = true;
                            }
                            else if (signUpOrIn == "3")
                            {
                                Console.WriteLine("Program Ending...");
                                menuChoiceValid = true;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice. Please try again.");
                                Console.ResetColor();
                            }
                        }
                        IsValidInput = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Sorry, you are too young to signup.");
                        Console.ResetColor();
                        IsValidInput = true;
                    }
                }
                else
                {
                    Console.WriteLine("Please input an actual age (numbers only).");
                }
            }
        }
    }
}