using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace.Book;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    public Book() { }

    public Book(Guid id, string title, string author) =>
        (Id, Title, Author) = (id, title, author);
}