using Core.Handlers;

namespace Core.Exceptions;

public class PatronNotFoundException : BaseException
{
    public PatronNotFoundException(string message) 
    : base(message, Severity.MEDIUM)
    {
    }
}
