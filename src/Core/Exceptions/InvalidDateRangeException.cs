using Core.Handlers;

namespace Core.Exceptions;

public class InvalidDateRangeException : BaseException
{
    public InvalidDateRangeException(string message) 
    : base(message, Severity.HIGH)
    {
    }    
}
