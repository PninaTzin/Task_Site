using Newtonsoft.Json;
using System.IO;

namespace Web_Api_Project.Helpers
{
    public static class JsonFileHelper
    {

        private static string EnsureDataDirectoryExists(string filePath)
        {
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return filePath;
        }
        public static void SaveToFile<T>(string filePath, List<T> data)
        {
            filePath = EnsureDataDirectoryExists(filePath);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        public static List<T> LoadFromFile<T>(string filePath)
        {
            filePath = EnsureDataDirectoryExists(filePath);

            if (!File.Exists(filePath))
            {
                return new List<T>();
            }
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
