using Core.Handlers;

namespace Core.Exceptions;

public class BorrowNotFoundException : BaseException
{
    public BorrowNotFoundException(string message) 
    : base(message, Severity.LOW)
    {
    }
}
