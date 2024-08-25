using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions;

public class PatronNotFoundException : BaseException
{
    public PatronNotFoundException(string message) 
    : base(message, Severity.LOW)
    {
    }
}
