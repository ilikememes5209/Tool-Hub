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
                Visuals.DisplayLogo();

                Console.WriteLine("--- Tool Hub Main Menu ---");
                string[] menuOptions = { "Calculator", "Unit Converter", "Weather", "Settings","Sign Out", "Exit" };

                for (int i = 0; i < menuOptions.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {menuOptions[i]}");
                }

                Console.WriteLine();
                bool IsValidInput = false;

                while (!IsValidInput)
                {
                    Console.Write("Please select an option (1-6):");
                    string input = Console.ReadLine();

                    switch (input)
                    {
                        case "1":
                            Visuals.SimulateLoading("Opening Calculator...");
                            IsValidInput = true;
                            calculatorApp.Calculator();
                            break;

                        case "2":
                            Visuals.SimulateLoading("Opening Unit Converter...");
                            IsValidInput = true;
                            unitConverter.unitConvert();
                            break;
                        
                        case "3":
                            Visuals.SimulateLoading("Opening Weather...");
                            IsValidInput = true;
                            weatherApp.ShowWeather().GetAwaiter().GetResult();
                            break;
                        case "4":
                            Visuals.SimulateLoading("Opening Settings...");
                            IsValidInput = true;
                            settingsMenu.OpenSettings();
                            break;
                            
                        case "5":
                            User.CurrentUser = null;
                            Visuals.SimulateLoading("Logging out...");
                            System.Threading.Thread.Sleep(1000);
                            return;


                        case "6":
                            Console.WriteLine("Exiting program...");
                            IsValidInput = true;
                            running = false;
                            break;

                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }
                }
            }
        }
    }
}