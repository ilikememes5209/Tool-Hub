using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

namespace mainProgram
{
    public class weatherApp
    {

        public static async Task ShowWeather()
        {
string apiKey = Environment.GetEnvironmentVariable("WEATHER_API_KEY");
            Console.Clear();
            Visuals.DisplayLogo();
            Console.WriteLine("--- Live Weather Tool ---");

            if (string.IsNullOrEmpty(apiKey))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Weather API Key not found in .env file.");
                Console.ResetColor();
                Console.ReadKey();
                return;
            }

            Console.Write("Enter City Name: ");
            string city = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(city)) return;

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=imperial";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Visuals.SimulateLoading("Connecting to weather service...");
                    string response = await client.GetStringAsync(url);

                    using (JsonDocument doc = JsonDocument.Parse(response))
                    {
                        string cityName = doc.RootElement.GetProperty("name").GetString();
                        double temp = doc.RootElement.GetProperty("main").GetProperty("temp").GetDouble();
                        string desc = doc.RootElement.GetProperty("weather")[0].GetProperty("description").GetString();

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("\n-------------------------------");
                        Console.WriteLine($"City:        {cityName}");
                        Console.WriteLine($"Temperature: {temp}°F");
                        Console.WriteLine($"Condition:   {char.ToUpper(desc[0]) + desc.Substring(1)}");
                        Console.WriteLine("-------------------------------");
                        Console.ResetColor();
                    }
                }
                catch (Exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nError: Could not find that city or API key is invalid.");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}