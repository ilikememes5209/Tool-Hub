using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace mainProgram
{
    public class SignIn
    {
        public static void login()
        {
            string fileName = "users.json";

            if (!File.Exists(fileName))
            {
                Console.WriteLine("No user database found. Please create an account first.");
                return;
            }

            Console.WriteLine("\n--- Login to Tool Hub ---");
            Console.Write("Username: ");
            string inputUsername = Console.ReadLine();

            Console.Write("Password: ");
            string inputPassword = AccountManager.GetMaskedPassword();

            try
            {
                string jsonContent = File.ReadAllText(fileName);
                List<User> users = JsonSerializer.Deserialize<List<User>>(jsonContent) ?? new List<User>();

                var user = users.FirstOrDefault(u => u.Username.Equals(inputUsername, StringComparison.OrdinalIgnoreCase));

                if (user != null)
                {
                    string hashedInput = AccountManager.HashPassword(inputPassword, user.Salt);

                    if (user.PasswordHash == hashedInput)
                    {
                        User.CurrentUser = user;
                        Console.WriteLine($"\nLogin successful! Welcome back, {user.Username}.");
                        Visuals.SimulateLoading("Entering Tool Hub...");
                        System.Threading.Thread.Sleep(1000);
                        mainMenu.ShowMenu();
                    }
                    else
                    {
                        Console.WriteLine("\nInvalid password.");
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid username.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nAn error occurred during login: {ex.Message}");
            }
        }
    }
}