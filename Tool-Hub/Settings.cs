
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Linq;

namespace mainProgram
{
    public class settingsMenu
    {
        public static void OpenSettings()
        {
            bool backToMenu = false;
            while (!backToMenu)
            {
                Visuals.DisplayLogo();
                Console.WriteLine("--- Settings ---");
                Console.WriteLine("1. View User Profile");
                Console.WriteLine("2. Change Theme Color");
                Console.WriteLine("3. Change Password");
                Console.WriteLine("4. Back to Main Menu");
                Console.Write("\nSelection: ");

                switch (Console.ReadLine())
                {
                    case "1": ShowProfile(); break;
                    case "2": ChangeColor(); break;
                    case "3": ChangePassword(); break;
                    case "4": backToMenu = true; break;
                }
            }
        }

        private static void ShowProfile()
        {
            Console.Clear();
            Console.WriteLine("--- User Profile ---");
            Console.WriteLine($"Username: {User.CurrentUser.Username}");
            Console.WriteLine($"Email:    {User.CurrentUser.Email}");
            Console.WriteLine($"User ID:  {User.CurrentUser.UserID}");
            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }

        private static void ChangeColor()
        {
            Console.Clear();
            Console.WriteLine("--- Choose a Theme Color ---");
            Console.WriteLine("1. Cyan");
            Console.WriteLine("2. Magenta");
            Console.WriteLine("3. Yellow");
            Console.WriteLine("4. White");
            Console.WriteLine("5. Green");
            Console.Write("\nSelection: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": User.CurrentUser.FavoriteColor = ConsoleColor.Cyan; break;
                case "2": User.CurrentUser.FavoriteColor = ConsoleColor.Magenta; break;
                case "3": User.CurrentUser.FavoriteColor = ConsoleColor.Yellow; break;
                case "4": User.CurrentUser.FavoriteColor = ConsoleColor.White; break;
                case "5": User.CurrentUser.FavoriteColor = ConsoleColor.Green; break;
            }

            SaveSettings();
            Console.WriteLine("Theme updated! Press any key...");
            Console.ReadKey();
        }

        private static void SaveSettings()
        {
            string fileName = "users.json";
            if (File.Exists(fileName))
            {
                var users = JsonSerializer.Deserialize<List<User>>(File.ReadAllText(fileName));
                var user = users.FirstOrDefault(u => u.UserID == User.CurrentUser.UserID);
                if (user != null)
                {
                    user.FavoriteColor = User.CurrentUser.FavoriteColor;
                    File.WriteAllText(fileName, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));
                }
            }
        }

        private static void ChangePassword()
        {
            Console.WriteLine("\n--- Change Password ---");
            Console.Write("Enter Current Password: ");
            string oldPassword = AccountManager.GetMaskedPassword();

            if (AccountManager.HashPassword(oldPassword, User.CurrentUser.Salt) != User.CurrentUser.PasswordHash)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect current password.");
                Console.ResetColor();
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter New Password: ");
            string newPassword = AccountManager.GetMaskedPassword();

            User.CurrentUser.PasswordHash = AccountManager.HashPassword(newPassword, User.CurrentUser.Salt);

            string fileName = "users.json";
            if (File.Exists(fileName))
            {
                try
                {
                    string json = File.ReadAllText(fileName);
                    var users = JsonSerializer.Deserialize<List<User>>(json) ?? new List<User>();

                    var userToUpdate = users.FirstOrDefault(u => u.UserID == User.CurrentUser.UserID);
                    if (userToUpdate != null)
                    {
                        userToUpdate.PasswordHash = User.CurrentUser.PasswordHash;
                        File.WriteAllText(fileName, JsonSerializer.Serialize(users, new JsonSerializerOptions { WriteIndented = true }));

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nPassword updated successfully!");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving password: {ex.Message}");
                }
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
}