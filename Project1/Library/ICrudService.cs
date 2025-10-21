using Library.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Common
{
    // Оновлено для C# 7.3
    public interface ICrudService<T> where T : class, IEntity
    {
        // 'public' видалено
        void Create(T element);

        // 'public' видалено і T? змінено на T
        T Read(Guid id);

        // 'public' видалено
        IEnumerable<T> ReadAll();

        // 'public' видалено
        void Update(T element);

        // 'public' видалено
        void Remove(T element);
    }
}