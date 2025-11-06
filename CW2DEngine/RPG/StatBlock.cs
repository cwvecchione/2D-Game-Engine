using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CW2DEngine.RPG
{
    internal class StatBlock
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MaxHP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public List<string> Abilities { get; set; }

        public StatBlock (string name, int hP, int maxHP, int attack, int defense, List<string> abilities)
        {
            Name = name;
            HP = hP;
            MaxHP = maxHP;
            Attack = attack;
            Defense = defense;
            Abilities = abilities;
        }
    }
}



public class JsonFileReader
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