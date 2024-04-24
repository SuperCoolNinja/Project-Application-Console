
using Newtonsoft.Json;
using ProjectOne.Models;
using ProjectOne.Static.Manager;

namespace ProjectOne.Static.Utility;


/// <summary>
/// Provides functionality to persist and retrieve object data in JSON format.
/// </summary>
internal static class JsonPersistance
{
    private const string EXTENSION = ".json";

    public static void SaveData(object data, string filename)
    {
        var filePath = Path.Combine(ApplicationManager.Path, filename + EXTENSION);
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);

        try
        {
            File.WriteAllText(filePath, json);
            Console.WriteLine($"Data saved to {filePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save data to {filePath}: {ex.Message}");
        }
    }

    public static DataModel? LoadData(string filename)
    {
        var filePath = Path.Combine(ApplicationManager.Path, filename + EXTENSION);
        Console.WriteLine($"Loading data from {filePath}...");

        if (File.Exists(filePath))
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<DataModel>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to load data from {filePath}: {ex.Message}");
                return null;
            }
        }
        else
        {
            Console.WriteLine($"File not found: {filePath}");
            return null;
        }
    }
}
