using Core.Handlers;

namespace Core.Exceptions;

public abstract class BaseException : Exception
{
    public string Message { get; set; }
    public Severity Severity { get; protected set; }

    public BaseException(string message, Severity severity) : base(message)
    {
        Message = message;
        Severity = severity;
    }
}
