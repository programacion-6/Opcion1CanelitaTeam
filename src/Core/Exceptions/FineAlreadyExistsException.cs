using Core.Handlers;

namespace Core.Exceptions;

public class FineAlreadyExistsException : BaseException
{
    public FineAlreadyExistsException(string message)
        : base(message, Severity.MEDIUM)
    { }
}
