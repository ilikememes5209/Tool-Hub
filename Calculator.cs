using System;

namespace mainProgram
{
    public class calculatorApp
    {
        public static void Calculator()
        {
            Console.Clear();
            Console.WriteLine("\n--- Calculator ---");
            Console.WriteLine("Welcome! Please enter your calculation below.");

            double num1 = GetValidNumber("Enter first number: ");

            Console.Write("Enter operator (+, -, *, /): ");
            string op = Console.ReadLine();

            double num2 = GetValidNumber("Enter second number: ");

            double result = 0;
            bool success = true;

            switch (op)
            {
                case "+":
                    result = num1 + num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error: Cannot divide by zero.");
                        Console.ResetColor();
                        success = false;
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Operator!");
                    Console.ResetColor();
                    success = false;
                    break;
            }

            if (success)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\nResult: {num1} {op} {num2} = {result}");
                Console.ResetColor();
            }

            Console.WriteLine("\nPress any key to return to the menu...");
            Console.ReadKey();
        }
        private static double GetValidNumber(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (double.TryParse(input, out number))
                {
                    return number;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid number (e.g., 10 or 15.5).");
                Console.ResetColor();
            }
        }
    }
}