using System;

namespace mainProgram
{
    public class mainMenu
    {
        public static void ShowMenu()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("--- Tool Hub Main Menu ---");
                string[] menuOptions = { "Calculator", "Exit" };

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {menuOptions[i]}");
                }

                Console.WriteLine();
                bool IsValidInput = false;

                while (!IsValidInput)
                {
                    Console.Write("Please select an option (1-2): ");
                    string input = Console.ReadLine();

                    if (input == "1")
                    {
                        Console.WriteLine("Opening Calculator...");
                        IsValidInput = true;
                        Console.ReadKey();
                        calculatorApp.Calculator();
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine("Exiting program. Goodbye!");
                        IsValidInput = true;
                        running = false;
                    }
                    else
                    { 
                        Console.WriteLine("Invalid selection. Please try again.");
                    }
                }
            }
        }
    }
}