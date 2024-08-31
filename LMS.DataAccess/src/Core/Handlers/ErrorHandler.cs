using Spectre.Console;

namespace LMS.DataAccess.Core.Handlers;

public class ErrorHandler
{
    public static void HandleError(Exception exception)
    {
        AnsiConsole.Write(
            new Panel(new Text($"{exception.Message}"))
                .Border(BoxBorder.Rounded)
                .BorderStyle(new Style(Color.Red))
                .Header("[bold red]ERROR[/]")
        );
    }
}
