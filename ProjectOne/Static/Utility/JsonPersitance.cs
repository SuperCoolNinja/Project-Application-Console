
using Newtonsoft.Json;
using ProjectOne.Static.Manager;

namespace ProjectOne.Static.Utility;

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
        }
        catch (Exception ex)
        {
            Logger.Write($"[Json Save] - {ex.Message}");
        }
    }

    public static object? LoadData(Type dataType, string filename)
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
