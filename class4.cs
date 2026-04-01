using System;

namespace mainProgram
{
    public class calculatorApp
    {

        public static void Calculator()
        {
            Console.WriteLine("\n--- Calculator ---");
            Console.WriteLine("Welcome! Please enter your calculation below.");

            Console.Write("Enter first number: ");
            double num1 = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter operator (+, -, *, /): ");
            string op = Console.ReadLine();

            Console.Write("Enter second number: ");
            double num2 = Convert.ToDouble(Console.ReadLine());

            double result = 0;

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
                        Console.WriteLine("Error: Cannot divide by zero.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Operator!");
                    return;
            }

            Console.WriteLine($"\nResult: {num1} {op} {num2} = {result}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}