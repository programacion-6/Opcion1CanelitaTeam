using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions.Abstracts;

public abstract class BaseException : Exception
{
    public string FriendlyMessage { get; set; }
    public Severity Severity { get; protected set; }

    public BaseException(string message, Severity severity) : base(message)
    {
        FriendlyMessage = message;
        Severity = severity;
    }
}
