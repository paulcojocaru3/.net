using Api3;
using DefaultNamespace.Book;
using DefaultNamespace.Book.Handlers;
using DefaultNamespace.Book.Requests;
using DefaultNamespace.Book.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
// Register the minimal API endpoints explorer (needed for OpenAPI/Swagger with minimal APIs)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

// Register Swagger/OpenAPI services so ISwaggerProvider is available for the middleware
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc
    (
        "v1",
        new OpenApiInfo
        {
            Title = "Book API",
            Version = "v1",
            Description = "API for managing users.",
            Contact = new OpenApiContact
            {
                Name = "API Support",
                Email = "support@example.com",


            }
        });
});

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

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI
        (
            c=>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "User Management API V1");
                c.RoutePrefix = string.Empty; 
                c.DisplayRequestDuration();
            }
        );
    
    app.MapOpenApi();
}

app.MapPost("/books", async (CreateBookRequest request, CreateBookHandler handler) =>
await handler.Handle(request));


app.MapGet("/books/{id}", async (Guid id, GetBookByIdHandler handler) =>
    await handler.Handle(new GetBookByIdQuery { Id = id }));

app.MapGet("/books", async (GetAllBooksHandler handler) => await handler.Handle(new GetAllBooksQuery()));

app.MapDelete("/books/{id}", async (Guid id, DeleteBookHandler handler) =>
await handler.Handle(new DeleteBookRequest { Id = id }));

app.Run();
