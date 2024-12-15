using System;

public enum Genre
{
    Fiction,
    NonFiction,
    Fantasy,
    ScienceFiction,
    Mystery
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public Genre Genre { get; set; }

    public Book(string? title, string? author, Genre genre)  // تغییر `string` به `string?`
    {
        Title = title ?? throw new ArgumentNullException(nameof(title), "Title cannot be null");
        Author = author ?? throw new ArgumentNullException(nameof(author), "Author cannot be null");
        Genre = genre;
    }
}
