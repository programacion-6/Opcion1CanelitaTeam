using Spectre.Console;

namespace userSystem.Concrete;

public class Patron : User
{
    public Patron(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password) : base(Name, MemberShipNumber, PhoneNumber, Direction, Password)
    {
    }

    public override void UserInformation()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold]========== Patron Information ==========[/]");
            AnsiConsole.MarkupLine($"[bold]Name:[/]               {Name}");
            AnsiConsole.MarkupLine($"[bold]Membership Number:[/]  {MemberShipNumber}");
            AnsiConsole.MarkupLine($"[bold]Phone Number:[/]       {PhoneNumber}");
            AnsiConsole.MarkupLine($"[bold]Direction:[/]          {Direction}");
            AnsiConsole.MarkupLine("[bold]=======================================[/]");
        }
}