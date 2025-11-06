using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace CW2DEngine.Utilities
{
    internal class JsonFetcher
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // Generic async method to fetch JSON from a URL and deserialize it into type T
        public static async Task<T?> FetchJsonFromUrlAsync<T>(string url)
        {
            try
            {
                // Send GET request
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                // Read response content
                string jsonString = await response.Content.ReadAsStringAsync();

                // Deserialize into object of type T
                T? data = JsonSerializer.Deserialize<T>(jsonString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return data;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Request error: {ex.Message}");
                throw;
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"JSON parsing error: {ex.Message}");
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
        string url = "https://example.com/api/users"; // Replace with your real API endpoint

        List<User>? users = await JsonFetcher.FetchJsonFromUrlAsync<List<User>>(url);

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