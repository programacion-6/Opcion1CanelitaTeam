using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions;

public class OutOfStockException : BaseException
{
    public OutOfStockException(string message) 
    : base(message, Severity.MEDIUM)
    {
    }    
}
