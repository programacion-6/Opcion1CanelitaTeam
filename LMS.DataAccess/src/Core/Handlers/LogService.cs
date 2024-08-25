namespace LMS.DataAccess.Core.Handlers;

public class LogService : ILogService
{
    private readonly string LogFilePath = "logs.txt";

    public void LogError(Severity severity, string message)
    {
        string LogMessage = $"[{DateTime.Now}] Severity: {severity} - Message: {message}";
        GenerateLogFile(LogMessage);
    }

    private void GenerateLogFile(string logMessage)
    {
        using (StreamWriter writer = new StreamWriter(LogFilePath, true))
        {
            writer.WriteLine(logMessage);
        }
    }
}
