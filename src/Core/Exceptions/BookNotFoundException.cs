using Core.Handlers;

namespace Core.Exceptions;

public class BookNotFoundException : BaseException
{
    public BookNotFoundException(string message) 
    : base(message, Severity.LOW)
    {
    }
}
