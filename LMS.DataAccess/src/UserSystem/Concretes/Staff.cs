using LMS.DataAccess.UserSystem.Entities;
using Spectre.Console;

namespace LMS.DataAccess.UserSystem.Concretes;

public class Staff : User
{
    public Staff(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password) : base(Name, MemberShipNumber, PhoneNumber, Direction, Password)
    {
    }

    public override void UserInformation()
        {
            AnsiConsole.Clear();
            AnsiConsole.MarkupLine("[bold]========== Staff Information ==========[/]");
            AnsiConsole.MarkupLine($"[bold]Name:[/]               {Name}");
            AnsiConsole.MarkupLine($"[bold]Membership Number:[/]  {MemberShipNumber}");
            AnsiConsole.MarkupLine($"[bold]Phone Number:[/]       {PhoneNumber}");
            AnsiConsole.MarkupLine($"[bold]Direction:[/]          {Direction}");
            AnsiConsole.MarkupLine("[bold]=======================================[/]");
        }
}