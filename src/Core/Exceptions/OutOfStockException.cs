using Core.Handlers;

namespace Core.Exceptions;

public class OutOfStockException : BaseException
{
    public OutOfStockException(string message) 
    : base(message, Severity.MEDIUM)
    {
    }    
}
