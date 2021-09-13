using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace CarAgencyAPI.Data
{
    public class DataManager<T>
    {
        private string _path;

        public DataManager(string path)
        {
            _path = path;
        }

        public void SaveData(IList<T> items)
        {
            File.WriteAllText(_path, JsonSerializer.Serialize(items));
        }

        public IList<T> ReadData()
        {
            IList<T> data = new List<T>();
            if (File.Exists(_path))
            {
                var dataJson = File.ReadAllText(_path);
                data = JsonSerializer.Deserialize<IList<T>>(dataJson);
            }
            return data;
        }
                
    }
}
