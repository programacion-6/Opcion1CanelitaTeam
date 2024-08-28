using LMS.DataAccess.Core.Exceptions.Abstracts;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions.Concretes;

public class FineAlreadyExistsException : BaseException
{
    public FineAlreadyExistsException(string message)
        : base(message, Severity.MEDIUM)
    { }
}
