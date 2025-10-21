using System; // Добавлено для Guid и DateTime
using System.Collections.Generic; // Добавлено для List
using System.Linq; // Добавлено для .Any()
using System.Text;

namespace Library.Common
{
    public class LibraryMember : IEntity
    {
        // Делегат
        public delegate void ItemBorrowedHandler(LibraryMember member, LibraryItem item);

        // Подія (Оновлено для C# 7.3 - прибрано '?')
        public event ItemBorrowedHandler OnItemBorrowed;

        // Властивість
        public Guid Id { get; set; }
        // Властивість
        public string FullName { get; set; }
        // Властивість
        public DateTime MemberSince { get; set; }

        private List<LibraryItem> _borrowedItems = new List<LibraryItem>();

        // Статичне поле
        private static int _totalMembers = 0;

        // Статичний конструктор
        static LibraryMember()
        {
            _totalMembers = 0;
            Console.WriteLine("LibraryMember class initialized. Total members: 0");
        }

        // Конструктор
        public LibraryMember(string fullName)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            MemberSince = DateTime.Now;
            _totalMembers++; // Інкремент статичного поля
        }

        // Метод
        public void BorrowItem(LibraryItem item)
        {
            _borrowedItems.Add(item);

            // Виклик події (синтаксис '?.Invoke' доступний в C# 7.3)
            OnItemBorrowed?.Invoke(this, item);
        }

        // Статичний метод
        public static int GetTotalMembersCount()
        {
            return _totalMembers;
        }

        public string GetBorrowedItemsList()
        {
            // Використовуємо .Any() замість _borrowedItems.Count > 0 для демонстрації Linq
            if (!_borrowedItems.Any())
                return "No items borrowed.";

            StringBuilder sb = new StringBuilder();
            foreach (var item in _borrowedItems)
            {
                sb.AppendLine($"- {item.Title}");
            }
            return sb.ToString();
        }
    }
}