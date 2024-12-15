using System;
using System.Collections.Generic;
using System.IO;

public static class FileManager
{
    private static string booksFilePath = "books.txt";
    private static string membersFilePath = "members.txt";
    private static string transactionsFilePath = "transactions.txt";

    // ذخیره‌سازی کتاب‌ها در فایل
    public static void SaveBooks(List<Book> books)
    {
        using (StreamWriter writer = new StreamWriter(booksFilePath))
        {
            foreach (var book in books)
            {
                writer.WriteLine($"{book.Title},{book.Author},{book.Genre}");
            }
        }
    }

    // بارگذاری کتاب‌ها از فایل
    public static List<Book> LoadBooks()
    {
        List<Book> books = new List<Book>();
        if (File.Exists(booksFilePath))
        {
            foreach (var line in File.ReadLines(booksFilePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && Enum.TryParse(parts[2], out Genre genre))
                {
                    books.Add(new Book(parts[0], parts[1], genre));
                }
            }
        }
        return books;
    }

    // ذخیره‌سازی اعضا در فایل
    public static void SaveMembers(List<Member> members)
    {
        using (StreamWriter writer = new StreamWriter(membersFilePath))
        {
            foreach (var member in members)
            {
                writer.WriteLine($"{member.Name},{member.MemberId}");
            }
        }
    }

    // بارگذاری اعضا از فایل
    public static List<Member> LoadMembers()
    {
        List<Member> members = new List<Member>();
        if (File.Exists(membersFilePath))
        {
            foreach (var line in File.ReadLines(membersFilePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 2)
                {
                    members.Add(new Member(parts[0], parts[1]));
                }
            }
        }
        return members;
    }

    // ذخیره‌سازی تراکنش‌ها در فایل
    public static void SaveTransactions(List<Transaction> transactions)
    {
        using (StreamWriter writer = new StreamWriter(transactionsFilePath))
        {
            foreach (var transaction in transactions)
            {
                writer.WriteLine($"{transaction.BookTitle},{transaction.MemberId},{transaction.Date}");
            }
        }
    }

    // بارگذاری تراکنش‌ها از فایل
    public static List<Transaction> LoadTransactions()
    {
        List<Transaction> transactions = new List<Transaction>();
        if (File.Exists(transactionsFilePath))
        {
            foreach (var line in File.ReadLines(transactionsFilePath))
            {
                var parts = line.Split(',');
                if (parts.Length == 3 && DateTime.TryParse(parts[2], out DateTime date))
                {
                    transactions.Add(new Transaction(parts[0], parts[1], date));
                }
            }
        }
        return transactions;
    }
}
