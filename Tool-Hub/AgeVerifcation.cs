using System;
using DotNetEnv;

namespace mainProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Env.Load();
            while (true)
            {
                Console.Clear();
                const int minimumSignupAge = 18;
                bool IsValidInput = false;
                Console.WriteLine("\n--- Age Verification ---");
                Console.WriteLine("Age Check: How old are you?");

                while (!IsValidInput)
                {
                    Console.Write("Age: ");
                    string ageInput = Console.ReadLine();

                    if (int.TryParse(ageInput, out int userAge))
                    {
                        if (userAge >= minimumSignupAge)
                        {
                            Console.Clear();
                            Console.WriteLine("\nAge check succeeded. Would you like to:");
                            Console.WriteLine("1. Create an account");
                            Console.WriteLine("2. Sign in");
                            Console.WriteLine("3. Exit");

                            bool menuChoiceValid = false;
                            while (!menuChoiceValid)
                            {
                                Console.Write("Please enter 1, 2, or 3: ");
                                string signUpOrIn = Console.ReadLine();

                                switch (signUpOrIn)
                                {
                                    case "1":
                                        Visuals.SimulateLoading("Redirecting to signup...");
                                        AccountManager.getInformation(userAge);
                                        menuChoiceValid = true;
                                        break;

                                    case "2":
                                        Visuals.SimulateLoading("Redirecting to Login...");
                                        SignIn.login();
                                        menuChoiceValid = true;
                                        break;

                                    case "3":
                                        Visuals.SimulateLoading("Program Ending...");
                                        menuChoiceValid = true;
                                        Environment.Exit(0);
                                        break;

                                    default:
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                                        Console.ResetColor();
                                        break;
                                }
                            }
                            IsValidInput = true;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry, you must be 18+ to sign up.");
                            Console.ReadKey();
                            Console.ResetColor();
                            IsValidInput = true;
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please input an actual age (numbers only).");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}