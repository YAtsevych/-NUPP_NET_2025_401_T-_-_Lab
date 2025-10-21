// Підключення нашої бібліотеки класів
using Library.Common;

Console.WriteLine("===== Library Management System Demo =====");

// 1. Демонстрація статичного конструктора і методів
Console.WriteLine($"Initial member count: {LibraryMember.GetTotalMembersCount()}");

// 2. Створення сервісів
var bookService = new GenericCrudService<Book>();
var journalService = new GenericCrudService<Journal>();
var memberService = new GenericCrudService<LibraryMember>();

// 3. Демонстрація Create (Створення)
Console.WriteLine("\n--- Creating new items ---");

var book1 = new Book("The C# Player's Guide", 2022, "R.B. Whitaker", "978-09855801-6-0", 500);
var book2 = new Book("Clean Code", 2008, "Robert C. Martin", "978-0132350884", 464);
var journal1 = new Journal("Tech Review", 2023, 12, "John Doe");

bookService.Create(book1);
bookService.Create(book2);
journalService.Create(journal1);

var member1 = new LibraryMember("Alice Smith");
memberService.Create(member1);

Console.WriteLine($"Book created: {book1.Title}");
Console.WriteLine($"Journal created: {journal1.Title}");
Console.WriteLine($"Member created: {member1.FullName}");
Console.WriteLine($"Current member count: {LibraryMember.GetTotalMembersCount()}");


// 4. Демонстрація ReadAll (Читання всіх)
Console.WriteLine("\n--- Reading all books ---");
foreach (var book in bookService.ReadAll())
{
    // 5. Демонстрація методу розширення (GetShortDescription)
    Console.WriteLine(book.GetShortDescription(50));
}

// 6. Демонстрація Read (Читання одного)
Console.WriteLine("\n--- Reading one specific book ---");
var foundBook = bookService.Read(book1.Id);
if (foundBook != null)
{
    Console.WriteLine($"Found: {foundBook.GetDetails()}");
}

// 7. Демонстрація Update (Оновлення)
Console.WriteLine("\n--- Updating a book ---");
if (foundBook != null)
{
    foundBook.Title = "The C# Player's Guide (Updated Edition)";
    bookService.Update(foundBook);

    var updatedBook = bookService.Read(foundBook.Id);
    Console.WriteLine($"Updated title: {updatedBook?.Title}");
}

// 8. Демонстрація Делегата та Події
// Підписуємося на подію
member1.OnItemBorrowed += (member, item) =>
{
    Console.WriteLine($"[EVENT] Member '{member.FullName}' just borrowed '{item.Title}'.");
};

Console.WriteLine("\n--- Demonstrating Events (Borrowing) ---");
member1.BorrowItem(book1);
member1.BorrowItem(journal1);
Console.WriteLine($"\nItems borrowed by {member1.FullName}:\n{member1.GetBorrowedItemsList()}");


// 9. Демонстрація Remove (Видалення)
Console.WriteLine("\n--- Removing 'Clean Code' ---");
bookService.Remove(book2);
Console.WriteLine("Books after removal:");
foreach (var book in bookService.ReadAll())
{
    Console.WriteLine($"- {book.Title}");
}

// 10. Демонстрація Додаткового Завдання (Save/Load)
string booksFilePath = "library_books.json";
string membersFilePath = "library_members.json";

Console.WriteLine($"\n--- Saving data to {booksFilePath} ---");
bookService.Save(booksFilePath);
memberService.Save(membersFilePath);
Console.WriteLine("Data saved.");

// Створимо нові сервіси, щоб показати завантаження
var newBookService = new GenericCrudService<Book>();
var newMemberService = new GenericCrudService<LibraryMember>();

Console.WriteLine("\n--- Loading data from files ---");
newBookService.Load(booksFilePath);
newMemberService.Load(membersFilePath);

Console.WriteLine("\nLoaded Books:");
foreach (var book in newBookService.ReadAll())
{
    Console.WriteLine($"- {book.Title} (by {book.Author})");
}

Console.WriteLine("\nLoaded Members:");
foreach (var member in newMemberService.ReadAll())
{
    Console.WriteLine($"- {member.FullName} (Member since: {member.MemberSince.ToShortDateString()})");
}

// Очистка файлів
File.Delete(booksFilePath);
File.Delete(membersFilePath);

Console.WriteLine("\n===== Demo Finished =====");