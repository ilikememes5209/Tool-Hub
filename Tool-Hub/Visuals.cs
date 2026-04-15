using System;

namespace mainProgram
{

    public static class Visuals
    {
        public static void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = User.CurrentUser?.FavoriteColor ?? ConsoleColor.Green;
            Console.WriteLine(@"
  ______            __   __  __      __    
 /_  __/___  ____  / /  / / / /_  __/ /_   
  / / / __ \/ __ \/ /  / /_/ / / / / __ \  
 / / / /_/ / /_/ / /  / __  / /_/ / /_/ /  
/_/  \____/\____/_/  /_/ /_/\__,_/_.___/   
        ");
            Console.ResetColor();
        }
        public static void SimulateLoading(string message, int durationMS = 1500)
        {
            if (User.CurrentUser != null && !User.CurrentUser.ShowAnimations)
            {
                Console.WriteLine($"{message} Done!");
                return;
            }
            char[] spinner = { '/', '-', '\\', '|' };
                int counter = 0;
                DateTime endTime = DateTime.Now.AddMilliseconds(durationMS);

                Console.Write(message + " ");

                Console.CursorVisible = false;

                while (DateTime.Now < endTime)
                {
                    Console.Write(spinner[counter % 4]);
                    System.Threading.Thread.Sleep(100);
                    Console.Write("\b");
                    counter++;
                }

                Console.CursorVisible = true;
                Console.WriteLine("Done!");
                System.Threading.Thread.Sleep(300);
            }
        }
    }
