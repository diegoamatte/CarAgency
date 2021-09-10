using System.IO;
using System.Collections.Generic;
using System.Text.Json;

namespace CarAgencyAPI.Data
{
    public class DataManager<T>
    {
        private string _path;

        public DataManager(string path)
        {
            _path = path;
        }

        public T Save(T t)
        {
            IList<T> items = GetItems();
            if (items.IndexOf(t) == -1)
            {
                items.Add(t);
                File.WriteAllText(_path, JsonSerializer.Serialize(items));
            }
            return t;
        }

        public IList<T> GetItems()
        {
            IList<T> data = new List<T>();
            if (File.Exists(_path))
            {
                var dataJson = File.ReadAllText(_path);
                data = JsonSerializer.Deserialize<IList<T>>(dataJson);
            }
            return data;
        }

        public T GetItem(int id)
        {
            var items = GetItems();
            T item = default(T);
            if (items.Count > id && id >= 0)
            {
                item = items[id];
            }
            return item;
        }

        public T UpdateItem(T t, int id)
        {
            var items = GetItems();
            items.Insert(id, t);
            return t;
        }

        public void DeleteItem(int id)
        {
            var items = GetItems();
            items.RemoveAt(id);
        }

    }
}
