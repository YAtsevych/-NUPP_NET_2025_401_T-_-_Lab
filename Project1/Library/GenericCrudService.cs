using System.Text.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.Common
{
    // Оновлено для C# 7.3
    public class GenericCrudService<T> : ICrudService<T> where T : class, IEntity
    {
        // Вбудована колекція .NET (словник для швидкого пошуку за Id)
        private readonly Dictionary<Guid, T> _items = new Dictionary<Guid, T>();

        public void Create(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            _items[element.Id] = element;
        }

        // T? змінено на T, щоб відповідати інтерфейсу C# 7.3
        public T Read(Guid id)
        {
            _items.TryGetValue(id, out var item);
            return item; // 'item' тут все ще може бути null, і це очікувано для 'T' (бо T - це class)
        }

        public IEnumerable<T> ReadAll()
        {
            return _items.Values.ToList();
        }

        public void Update(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            if (_items.ContainsKey(element.Id))
            {
                _items[element.Id] = element;
            }
        }

        public void Remove(T element)
        {
            if (element != null)
            {
                _items.Remove(element.Id);
            }
        }

        // --- Додаткове завдання ---

        // Метод для збереження даних у файл
        public void Save(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(_items.Values, options);
            File.WriteAllText(filePath, json);
        }

        // Метод для завантаження даних із файлу
        public void Load(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            string json = File.ReadAllText(filePath);
            var loadedItems = JsonSerializer.Deserialize<List<T>>(json);

            _items.Clear();
            if (loadedItems != null)
            {
                foreach (var item in loadedItems)
                {
                    Create(item);
                }
            }
        }
    }
}