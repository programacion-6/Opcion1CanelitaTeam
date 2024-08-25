using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions;

public class FineAlreadyExistsException : BaseException
{
    public FineAlreadyExistsException(string message)
        : base(message, Severity.MEDIUM)
    { }
}
