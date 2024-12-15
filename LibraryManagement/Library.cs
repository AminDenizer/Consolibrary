using System;
using System.Collections.Generic;

public class Library
{
    public List<Book> Books { get; set; } = new List<Book>();
    public List<Member> Members { get; set; } = new List<Member>();
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    // متد برای افزودن کتاب
    public void AddBook(Book book)
    {
        if (book == null) throw new ArgumentNullException(nameof(book));
        Books.Add(book);
    }

    // متد برای افزودن عضو
    public void AddMember(Member member)
    {
        if (member == null) throw new ArgumentNullException(nameof(member));
        Members.Add(member);
    }

    // متد برای قرض گرفتن کتاب
    public void BorrowBook(string? bookTitle, string? memberId)  // تغییر `string` به `string?`
    {
        if (string.IsNullOrWhiteSpace(bookTitle))
            throw new ArgumentException("Book title cannot be null or empty.", nameof(bookTitle));
        if (string.IsNullOrWhiteSpace(memberId))
            throw new ArgumentException("Member ID cannot be null or empty.", nameof(memberId));

        var book = Books.Find(b => b.Title == bookTitle);
        var member = Members.Find(m => m.MemberId == memberId);

        if (book == null)
            throw new ArgumentException("Book not found", nameof(bookTitle));
        if (member == null)
            throw new ArgumentException("Member not found", nameof(memberId));

        Transactions.Add(new Transaction(bookTitle, memberId, DateTime.Now));
    }

    // نمایش کتاب‌ها
    public void DisplayBooks()
    {
        foreach (var book in Books)
        {
            Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Genre: {book.Genre}");
        }
    }

    // نمایش اعضا
    public void DisplayMembers()
    {
        foreach (var member in Members)
        {
            Console.WriteLine($"Name: {member.Name}, MemberId: {member.MemberId}");
        }
    }

    // نمایش تراکنش‌ها
    public void DisplayTransactions()
    {
        foreach (var transaction in Transactions)
        {
            Console.WriteLine($"Book: {transaction.BookTitle}, MemberId: {transaction.MemberId}, Date: {transaction.Date}");
        }
    }
}
