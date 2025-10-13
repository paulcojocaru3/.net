using Api3;
using DefaultNamespace.Book.Queries;

namespace DefaultNamespace.Book.Handlers;

public class GetBookByIdHandler
{
    private readonly AppDbContext _db;
    public GetBookByIdHandler(AppDbContext db) => _db = db;

    public async Task<Book?> Handle(GetBookByIdQuery query) =>
        await _db.Books.FindAsync(query.Id);
}
