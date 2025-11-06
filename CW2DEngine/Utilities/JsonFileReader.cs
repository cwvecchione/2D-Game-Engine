using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace CW2DEngine.Utilities
{
    internal class JsonFileReader
    {
        // Generic function to fetch data from a JSON file and deserialize it into a type T
        public static async Task<T?> FetchDataAsync<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file '{filePath}' was not found.");
            }

            try
            {
                // Read file contents asynchronously
                string jsonString = await File.ReadAllTextAsync(filePath);

                // Deserialize JSON into object of type T
                T? data = JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = true
                });

                return data;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error parsing JSON: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
                throw;
            }
        }
    }
}

/*
Example

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string filePath = "users.json";
        List<User>? users = await JsonFileReader.FetchDataAsync<List<User>>(filePath);

        if (users != null)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}");
            }
        }
    }
}

*/