using Microsoft.EntityFrameworkCore;
using DefaultNamespace.Book;

namespace Api3;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
