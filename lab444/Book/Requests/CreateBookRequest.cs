using System.ComponentModel.DataAnnotations;

namespace DefaultNamespace.Book.Requests;

public class CreateBookRequest
{
    public string Title { get; set; }
    public string Author { get; set; }
}
