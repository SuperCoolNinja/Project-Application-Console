
using Newtonsoft.Json;
using ProjectOne.Static.Manager;

namespace ProjectOne.Static.Utility;


/// <summary>
/// Provides functionality to persist and retrieve object data in JSON format.
/// </summary>
internal static class JsonPersistance
{
    private const string EXTENSION = ".json";
    private const string DEFAULT_FILE_NAME = "data";


    /// <summary>
    /// Persists an object data to a JSON file.
    /// </summary>
    /// <param name="data">The object to be saved.</param>
    /// <param name="filename">The name of the file to save the data. Default is "data".</param>
    public static void SaveData(object data, string filename = DEFAULT_FILE_NAME)
    {
        var filePath = Path.Combine(ApplicationManager.Path, filename + EXTENSION);
        var json = JsonConvert.SerializeObject(data, Formatting.Indented);

        try
        {
            File.WriteAllText(filePath, json);
        }
        catch (Exception ex)
        {
            Logger.Write($"[Json Save] - {ex.Message}");
        }
    }

    /// <summary>
    /// Loads object data from a JSON file.
    /// </summary>
    /// <param name="dataType">The type of the object to load.</param>
    /// <param name="filename">The name of the file to load the data from. Default is "data".</param>
    /// <returns>The loaded object data, or null if the file is not found or an error occurs.</returns>
    public static object? LoadData(Type dataType, string filename = DEFAULT_FILE_NAME)
    {
        var filePath = Path.Combine(ApplicationManager.Path, filename + EXTENSION);
        if (File.Exists(filePath))
        {
            try
            {
                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject(json, dataType);
            }
            catch (Exception ex)
            {
                Logger.Write($" [Json - Load] - {ex.Message}");
            };

            return null;
        }
        else
        {
            Logger.Write($"[Json - Load] File not found :  {filename}");
            return null;
        }
    }
}
