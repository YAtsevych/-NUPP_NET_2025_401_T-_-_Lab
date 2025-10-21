using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    // Статичний клас для методів розширення
    public static class ModelExtensions
    {
        // Метод розширення
        public static string GetShortDescription(this LibraryItem item, int maxLength)
        {
            string details = item.GetDetails();
            if (details.Length <= maxLength)
            {
                return details;
            }
            return details.Substring(0, maxLength - 3) + "...";
        }
    }
}