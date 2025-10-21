using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    // Абстрактний базовий клас
    public abstract class LibraryItem : IEntity
    {
        // Властивість
        public Guid Id { get; set; }
        // Властивість
        public string Title { get; set; }
        // Властивість
        public int PublicationYear { get; set; }

        // Конструктор
        public LibraryItem(string title, int publicationYear)
        {
            Id = Guid.NewGuid();
            Title = title;
            PublicationYear = publicationYear;
        }

        // Абстрактний метод
        public abstract string GetDetails();
    }
}
