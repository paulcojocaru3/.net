using Api3;
using DefaultNamespace.Book.Queries;
using Microsoft.EntityFrameworkCore;

namespace DefaultNamespace.Book.Handlers;

public class GetAllBooksHandler
{
    private readonly AppDbContext _db;
    public GetAllBooksHandler(AppDbContext db) => _db = db;

    public async Task<List<Book>> Handle(GetAllBooksQuery _) =>
        await _db.Books.ToListAsync();
}
