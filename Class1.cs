using System;
using System.IO;

namespace mainProgram
{
    public class AccountManager
    {
        private static string GetMaskedPassword()
        {
            string password = "";
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey(true);
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password += key.KeyChar;
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Substring(0, (password.Length - 1));
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();
            return password;
        }

        public static void getInformation(int userAge)
        {
            Console.WriteLine("Welcome To the Tool Hub");

            string yesOrNo1 = "";
            bool IsValidInput = false;

           
            while (!IsValidInput)
            {
                Console.WriteLine("Create Your Account? Y/N?");
                yesOrNo1 = Console.ReadLine()?.ToLower();

                if (yesOrNo1 == "y" || yesOrNo1 == "yes" || yesOrNo1 == "n" || yesOrNo1 == "no")
                {
                    IsValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter 'Yes' or 'No'.");
                }
            }

            
            if (yesOrNo1 == "y" || yesOrNo1 == "yes")
            {
                Console.WriteLine("Please enter your new username:");
                string userName = Console.ReadLine();
                Console.WriteLine("Please enter your email:");
                string userEmail = Console.ReadLine();
                Console.WriteLine("Please enter your password:");
                string userPassword = GetMaskedPassword();

                Console.WriteLine($"Thank you {userName}, your account with email {userEmail} has been created!");

                string fileName = "users.txt";

                
                int userId = 1;
                if (File.Exists(fileName))
                {
                    
                    string content = File.ReadAllText(fileName);
                    userId = System.Text.RegularExpressions.Regex.Matches(content, "Username:").Count + 1;
                }

                
                string[] userData = {
        "----------------------------",
        $"UserID:   {userId}",
        $"Username: {userName}",
        $"Email:    {userEmail}",
        $"Password: {userPassword}",
        $"Age:      {userAge}",
        "----------------------------",
        ""
    };

                File.AppendAllLines(fileName, userData);

                Console.WriteLine($"Account created! Your UserID is: {userId}. Remeber this!");

                string yesOrNo2 = "";
                bool isValidInput = false;


                while (!isValidInput)
                {
                    Console.WriteLine("Would you like to enter the Tool Hub? Y/N?");
                    yesOrNo2 = Console.ReadLine()?.ToLower();

                    if (yesOrNo2 == "y" || yesOrNo2 == "yes" || yesOrNo2 == "n" || yesOrNo2 == "no")
                    {
                        isValidInput = true;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input. Please enter 'Yes' or 'No'.");
                    }
                }

                
                if (yesOrNo2 == "y" || yesOrNo2 == "yes")
                { 
                    mainMenu.ShowMenu();
                }
                else
                {
                    Console.WriteLine("Exiting App...");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Exiting App...");
                Environment.Exit(0);
            }
        }
    }
}