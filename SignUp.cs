using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace mainProgram
{
    

    public class AccountManager
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static string GetMaskedPassword()
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
            string fileName = "users.json"; // Defined the filename
            List<User> userList = new List<User>(); // Defined the list

            Console.WriteLine("\n--- Sign Up For Tool Hub ---");
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

                string userSalt = GenerateSalt();
                string securedPassword = HashPassword(userPassword, userSalt);

                if (File.Exists(fileName))
                {
                    try
                    {
                        string existingJson = File.ReadAllText(fileName);
                        userList = JsonSerializer.Deserialize<List<User>>(existingJson) ?? new List<User>();
                    }
                    catch (Exception)
                    {
                        userList = new List<User>();
                    }
                }

                int userId = userList.Count + 1;

                User newUser = new User
                {
                    UserID = userId,
                    Username = userName,
                    Email = userEmail,
                    PasswordHash = securedPassword,
                    Salt = userSalt,
                    Age = userAge
                };

                userList.Add(newUser);
                string updatedJson = JsonSerializer.Serialize(userList, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(fileName, updatedJson);

                Console.WriteLine($"\nThank you {userName}, your account has been created!");

                string yesOrNo2 = "";
                bool isValidInput2 = false;
                while (!isValidInput2)
                {
                    Console.WriteLine("\nWould you like to enter the Tool Hub? Y/N?");
                    yesOrNo2 = Console.ReadLine()?.ToLower();

                    if (yesOrNo2 == "y" || yesOrNo2 == "yes" || yesOrNo2 == "n" || yesOrNo2 == "no")
                        isValidInput2 = true;
                    else
                        Console.WriteLine("Invalid input. Please enter 'Yes' or 'No'.");
                }

                if (yesOrNo2 == "y" || yesOrNo2 == "yes")
                {
                    Visuals.SimulateLoading("Entering Tool Hub...");
                    User.CurrentUser = newUser;
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