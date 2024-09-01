using LMS.DataAccess.Console.UserMenu.PatronMenu;
using LMS.DataAccess.Console.UserMenu.StaffMenu;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;
using Spectre.Console;

namespace LMS.DataAccess.Console.LoginMenu;

public class Login
{
    private readonly PatronManager _patrons;
    private readonly StaffManager _staffs;
    private readonly BorrowManager _borrows;
    private readonly BookRepository _books;
    private readonly FineManager _fines;

    public Login(PatronManager patrons, StaffManager staffs, BorrowManager borrows, BookRepository books, FineManager fines)
    {
        _patrons = patrons;
        _staffs = staffs;
        _borrows = borrows;
        _books = books;
        _fines = fines;
    }

    public void LoginMenu()
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[green]===== Login =====[/]");

        string? username = AnsiConsole.Ask<string>("Enter [yellow]Username[/]:");
        string? password = AnsiConsole.Prompt(
            new TextPrompt<string>("Enter [yellow]Password[/]:")
                .PromptStyle("red")
                .Secret());

        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            Staff? staff = _staffs.ValidateStaff(username, password);
            if (staff != null)
            {
                AnsiConsole.MarkupLine($"[green]Welcome, {staff.getName()} (Staff)![/]");
                var staffOptions = new StaffMenu(staff, _borrows, _books, _patrons, _fines);
                staffOptions.UserMenu();
                return;
            }

            Patron? patron = _patrons.ValidatePatron(username, password);
            if (patron != null)
            {
                AnsiConsole.MarkupLine($"[green]Welcome, {patron.getName()} (Patron)![/]");
                var patronOptions = new PatronMenu(patron, _borrows, _books, _fines);
                patronOptions.UserMenu();
                return;
            }
        }

        AnsiConsole.MarkupLine("[red]Invalid username or password. Please try again.[/]");
        var menu = new WelcomeMenu(_patrons, _staffs, _borrows, _books, _fines);
        Pause();
        menu.ShowMenu();
    }
    private void Pause()
    {
        AnsiConsole.MarkupLine("[gray]Press any key to continue...[/]");
        System.Console.ReadKey(true);
        AnsiConsole.Clear();
    }
}
