using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions;

public class BookNotFoundException : BaseException
{
    public BookNotFoundException(string message) 
    : base(message, Severity.LOW)
    {
    }
}
