namespace DefaultNamespace;

public class BookNotFoundException : BaseException
{
    public BookNotFoundException(Guid bookId): base($"Book with id '{bookId}' was not found.", 404, "BOOK_NOT_FOUND")
    {
    }
}