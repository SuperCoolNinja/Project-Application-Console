
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

    public static void SaveData(object data)
    {
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);

        try
        {
            using (StreamWriter writer = new StreamWriter(ApplicationManager.FilePath, false))
            {
                writer.Write(json);
            }

            Logger.Write($"Data saved to {ApplicationManager.FilePath}.");
        }
        catch (Exception ex)
        {
            Logger.Write($"Failed to save data to {ApplicationManager.FilePath}: {ex.Message}");
            ApplicationManager.IsExiting = true;
        }
    }


    public static DataModel? LoadData()
    {
        var filePath = ApplicationManager.FilePath;
        Logger.Write($"Loading data from {filePath}...");

        if (!Path.IsPathRooted(filePath) || filePath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
        {
            Logger.Write($"Invalid file path: {filePath}");
            return null;
        }

        if (!filePath.EndsWith(JSON_EXTENSION))
        {
            Logger.Write($"Invalid JSON file path: {filePath}");
            return null;
        }

        try
        {
            using (var fileStream = File.OpenText(filePath))
            {
                var json = fileStream.ReadToEnd();
                Logger.Write("Data loaded successfully.");
                return JsonConvert.DeserializeObject<DataModel>(json);
            }
        }
        catch (Exception ex)
        {
            Logger.Write($"Failed to load data from {filePath}: {ex.Message}");
            return null;
        }
    }
}
