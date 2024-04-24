
using Newtonsoft.Json;
using ProjectOne.Models;
using ProjectOne.Static.Manager;

namespace ProjectOne.Static.Utility;


/// <summary>
/// Provides functionality to persist and retrieve object data in JSON format.
/// </summary>
internal static class JsonPersistance
{
    private const string JSON_EXTENSION = ".json";

    public static void SaveData(object data, string filePath)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);

        try
        {
            File.WriteAllText(filePath, json);
            Logger.Write($"Data saved to {filePath}.");
        }
        catch (Exception ex)
        {
            Logger.Write($"Failed to save data to {filePath}: {ex.Message}");
            ApplicationManager.IsExiting = true;
        }
    }


    public static DataModel? LoadData(string filePath)
    {
        Logger.Write($"Loading data from {filePath}...");

        if (!File.Exists(filePath))
        {
            Logger.Write($"Loading data from {filePath}...");
            ApplicationManager.IsExiting = true;
            return null;
        }

        if (!filePath.EndsWith(JSON_EXTENSION))
        {
            Logger.Write($"Invalid JSON file path: {filePath}");
            ApplicationManager.IsExiting = true;
            return null;
        }

        try
        {
            var json = File.ReadAllText(filePath);
            Logger.Write($"data loaded successfully.");
            return JsonConvert.DeserializeObject<DataModel>(json);
        }
        catch (Exception ex)
        {
            Logger.Write($"Failed to load data from {filePath}: {ex.Message}");
            ApplicationManager.IsExiting = true;
            return null;
        }

    }

}
