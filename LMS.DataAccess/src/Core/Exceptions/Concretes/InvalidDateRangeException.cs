using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions;

public class InvalidDateRangeException : BaseException
{
    public InvalidDateRangeException(string message) 
    : base(message, Severity.HIGH)
    {
    }    
}
