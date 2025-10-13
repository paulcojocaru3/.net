using Api3;
using DefaultNamespace.Book.Requests;

namespace DefaultNamespace.Book.Handlers;

public class DeleteBookHandler
{
    private readonly AppDbContext _db;
    public DeleteBookHandler(AppDbContext db) => _db = db;

    public async Task<bool> Handle(DeleteBookRequest request)
    {
        var book = await _db.Books.FindAsync(request.Id);
        if (book == null) return false;
        _db.Books.Remove(book);
        await _db.SaveChangesAsync();
        return true;
    }
}
