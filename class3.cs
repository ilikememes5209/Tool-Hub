using System;
using System.IO;

namespace mainProgram
{
    public class SignIn
    {
        public static void login()
        {
            string fileName = "users.txt";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("No user database found. Please create an account first.");
                return;
            }

            Console.WriteLine("\n--- Login to Tool Hub ---");
            Console.Write("Username: ");
            string inputUsername = Console.ReadLine();

            Console.Write("Password: ");
            string inputPassword = "";

            while (true)
            {
                var key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (inputPassword.Length > 0)
                    {
                        inputPassword = inputPassword.Substring(0, inputPassword.Length - 1);
                        Console.Write("\b \b");
                    }
                }
                else if (!char.IsControl(key.KeyChar))
                {
                    inputPassword += key.KeyChar;
                    Console.Write("*");
                }
            }

            bool isAuthenticated = false;
            string[] lines = File.ReadAllLines(fileName);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == $"Username: {inputUsername}")
                { 
                    if (i + 2 < lines.Length && lines[i + 2] == $"Password: {inputPassword}")
                    {
                        isAuthenticated = true;
                        break;
                    }
                }
            }

            if (isAuthenticated)
            {
                Console.WriteLine($"\nLogin successful! Welcome back, {inputUsername}.");
                Console.ReadKey();
                mainMenu.ShowMenu();
            }
            else
            {
                Console.WriteLine("\nInvalid username or password.");
            }
        }
    }
}