using System;
using System.Collections.Generic;
using System.Linq;  // برای استفاده از LINQ

class Program
{
    static void Main()
    {
        // ایجاد نمونه از کلاس کتابخانه
        Library library = new Library();

        // بارگذاری کتاب‌ها، اعضا و تراکنش‌ها از فایل‌ها
        library.Books = FileManager.LoadBooks() ?? new List<Book>(); // اگر LoadBooks() null برگرداند، یک لیست خالی می‌دهیم
        library.Members = FileManager.LoadMembers() ?? new List<Member>(); // اگر LoadMembers() null برگرداند، یک لیست خالی می‌دهیم
        library.Transactions = FileManager.LoadTransactions() ?? new List<Transaction>(); // اگر LoadTransactions() null برگرداند، یک لیست خالی می‌دهیم

        // حلقه برای منوی اصلی
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Library System");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Member");
            Console.WriteLine("3. Borrow Book");
            Console.WriteLine("4. View Books");
            Console.WriteLine("5. View Members");
            Console.WriteLine("6. View Transactions");
            Console.WriteLine("0. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine() ?? ""; // اگر null باشد، یک رشته خالی می‌دهیم

            switch (choice)
            {
                case "1":
                    Console.Write("Enter book title: ");
                    string title = Console.ReadLine() ?? "Unknown Title";  // اگر null باشد، مقدار پیش‌فرض می‌دهیم
                    Console.Write("Enter book author: ");
                    string author = Console.ReadLine() ?? "Unknown Author"; // اگر null باشد، مقدار پیش‌فرض می‌دهیم
                    Console.Write("Enter book genre (0=Fiction, 1=NonFiction, 2=Mystery, 3=Fantasy, 4=ScienceFiction, 5=Biography): ");

                    if (Enum.TryParse(Console.ReadLine(), out Genre genre))
                    {
                        library.AddBook(new Book(title, author, genre));
                    }
                    break;

                case "2":
                    // نام عضو باید فقط شامل حروف و فاصله باشد
                    string name = "";
                    while (true)
                    {
                        Console.Write("Enter member name: ");
                        name = Console.ReadLine() ?? "Unknown Name";  // اگر null باشد، مقدار پیش‌فرض می‌دهیم

                        if (IsValidName(name))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid name. Name must contain only letters and spaces, and cannot be empty.");
                        }
                    }

                    // شناسه عضو باید فقط شامل اعداد باشد
                    string memberId = "";
                    while (true)
                    {
                        Console.Write("Enter member ID (numeric): ");
                        memberId = Console.ReadLine() ?? "Unknown ID"; // اگر null باشد، مقدار پیش‌فرض می‌دهیم

                        if (IsValidId(memberId))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Member ID must be a number.");
                        }
                    }

                    library.AddMember(new Member(name, memberId));
                    break;

                case "3":
                    Console.Write("Enter book title: ");
                    string bookTitle = Console.ReadLine() ?? "Unknown Book Title";  // اگر null باشد، مقدار پیش‌فرض می‌دهیم
                    Console.Write("Enter member ID: ");
                    string borrowMemberId = Console.ReadLine() ?? "Unknown Member ID"; // اگر null باشد، مقدار پیش‌فرض می‌دهیم

                    library.BorrowBook(bookTitle, borrowMemberId);
                    break;

                case "4":
                    library.DisplayBooks();
                    Console.ReadKey();
                    break;

                case "5":
                    library.DisplayMembers();
                    Console.ReadKey();
                    break;

                case "6":
                    library.DisplayTransactions();
                    Console.ReadKey();
                    break;

                case "0":
                    // تایید خروج
                    Console.WriteLine("Are you sure you want to exit? (y/n): ");
                    string exitConfirmation = Console.ReadLine()?.ToLower() ?? "n"; // اگر null باشد، مقدار پیش‌فرض "n" قرار می‌دهیم

                    if (exitConfirmation == "y")
                    {
                        // ذخیره اطلاعات به فایل
                        FileManager.SaveBooks(library.Books);
                        FileManager.SaveMembers(library.Members);
                        FileManager.SaveTransactions(library.Transactions);
                        return; // خروج از برنامه
                    }
                    break;
            }
        }
    }

    // متد برای اعتبارسنجی نام
    static bool IsValidName(string name)
    {
        // فقط حروف و فاصله‌ها مجاز هستند
        return !string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || c == ' ');
    }

    // متد برای اعتبارسنجی شناسه
    static bool IsValidId(string id)
    {
        return int.TryParse(id, out _);
    }
}
