using System;

public class Transaction
{
    public string BookTitle { get; set; }
    public string MemberId { get; set; }
    public DateTime Date { get; set; }

    // سازنده تراکنش
    public Transaction(string bookTitle, string memberId, DateTime date)
    {
        BookTitle = bookTitle ?? throw new ArgumentNullException(nameof(bookTitle));
        MemberId = memberId ?? throw new ArgumentNullException(nameof(memberId));
        Date = date;
    }
}
