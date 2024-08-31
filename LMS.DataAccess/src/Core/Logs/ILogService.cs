using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Logs;

public interface ILogService
{
    void LogError(Severity severity, string message);
}
