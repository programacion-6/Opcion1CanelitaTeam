using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions;

public class BorrowNotFoundException : BaseException
{
    public BorrowNotFoundException(string message) 
    : base(message, Severity.LOW)
    {
    }
}
