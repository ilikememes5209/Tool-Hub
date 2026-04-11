using System;

namespace mainProgram
{
    public class unitConverter
    {
        public static void unitConvert()
        {
            bool backToMenu = false;

            while (!backToMenu)
            {
                Console.Clear();
                Console.WriteLine("\n--- Unit Converter ---");
                Console.WriteLine("1. Length (Meters to Feet)");
                Console.WriteLine("2. Temperature (Celsius to Fahrenheit)");
                Console.WriteLine("3. Weight (Kilograms to Pounds)");
                Console.WriteLine("4. Digital Storage (Megabytes to Gigabytes)");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nSelect an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ConvertLength();
                        break;
                    case "2":
                        ConvertTemperature();
                        break;
                    case "3":
                        ConvertWeight();
                        break;
                    case "4":
                        ConvertDigitalStorage();
                        break;
                    case "5":
                        backToMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ConvertLength()
        {
            Console.Write("\nEnter distance in Meters: ");
            if (double.TryParse(Console.ReadLine(), out double meters))
            {
                double feet = meters * 3.28084;
                Console.WriteLine($"{meters} Meters is approximately {feet:F2} Feet.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void ConvertTemperature()
        {
            Console.Write("\nEnter temperature in Celsius: ");
            if (double.TryParse(Console.ReadLine(), out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                Console.WriteLine($"{celsius}°C is {fahrenheit:F2}°F.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void ConvertWeight()
        {
            Console.Write("\nEnter weight in Kilograms: ");
            if (double.TryParse(Console.ReadLine(), out double kg))
            {
                double lbs = kg * 2.20462;
                Console.WriteLine($"{kg} kg is approximately {lbs:F2} lbs.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numerical value.");
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void ConvertDigitalStorage()
        {
            Console.Write("\nEnter size in Megabytes (MB): ");
            if (double.TryParse(Console.ReadLine(), out double mb))
            {
                double gb = mb / 1024;
                Console.WriteLine($"{mb} MB is {gb:F4} GB.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numerical value.");
            }
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}