using Api3;
using DefaultNamespace.Book;
using DefaultNamespace.Book.Handlers;
using DefaultNamespace.Book.Requests;
using DefaultNamespace.Book.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite("Data Source=books.db"));
builder.Services.AddScoped<CreateBookHandler>();
builder.Services.AddScoped<DeleteBookHandler>();
builder.Services.AddScoped<GetBookByIdHandler>();
builder.Services.AddScoped<GetAllBooksHandler>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

app.MapPost("/books", async (CreateBookRequest request, CreateBookHandler handler) =>
await handler.Handle(request));


app.MapGet("/books/{id}", async (Guid id, GetBookByIdHandler handler) =>
    await handler.Handle(new GetBookByIdQuery { Id = id }));

app.MapGet("/books", async (GetAllBooksHandler handler) => await handler.Handle(new GetAllBooksQuery()));

app.MapDelete("/books/{id}", async (Guid id, DeleteBookHandler handler) =>
await handler.Handle(new DeleteBookRequest { Id = id }));

app.Run();
