using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    // Клас-нащадок
    public class Journal : LibraryItem
    {
        // Властивість
        public int IssueNumber { get; set; }
        // Властивість
        public string Editor { get; set; }

        // Конструктор
        public Journal(string title, int publicationYear, int issueNumber, string editor)
            : base(title, publicationYear)
        {
            IssueNumber = issueNumber;
            Editor = editor;
        }

        // Реалізація абстрактного методу
        public override string GetDetails()
        {
            return $"Journal: '{Title}', Issue {IssueNumber} ({PublicationYear}). Editor: {Editor}.";
        }
    }
}
