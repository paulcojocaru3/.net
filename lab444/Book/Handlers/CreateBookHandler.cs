using Api3;
using DefaultNamespace.Book.Requests;

namespace DefaultNamespace.Book.Handlers;

public class CreateBookHandler
{
    private readonly AppDbContext _db;
    public CreateBookHandler(AppDbContext db) => _db = db;

    public async Task<Book> Handle(CreateBookRequest request)
    {
        var book = new Book(Guid.NewGuid(), request.Title, request.Author);
        _db.Books.Add(book);
        await _db.SaveChangesAsync();
        return book;
    }
}
