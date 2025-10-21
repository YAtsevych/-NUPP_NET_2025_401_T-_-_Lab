using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    // Клас-нащадок
    public class Book : LibraryItem
    {
        // Властивість
        public string Author { get; set; }
        // Властивість
        public string ISBN { get; set; }
        // Властивість
        public int PageCount { get; set; }

        // Конструктор (викликає базовий конструктор)
        public Book(string title, int publicationYear, string author, string isbn, int pageCount)
            : base(title, publicationYear)
        {
            Author = author;
            ISBN = isbn;
            PageCount = pageCount;
        }

        // Реалізація абстрактного методу
        public override string GetDetails()
        {
            return $"Book: '{Title}' by {Author}, {PublicationYear} year. ISBN: {ISBN}.";
        }
    }
}