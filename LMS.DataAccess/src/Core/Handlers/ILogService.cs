namespace LMS.DataAccess.Core.Handlers;

public interface ILogService
{
    void LogError(Severity severity, string message);
}
