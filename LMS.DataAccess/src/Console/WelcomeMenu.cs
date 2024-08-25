using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.Console.LoginMenu;
using LMS.DataAccess.FineSystem;
using LMS.DataAccess.UserSystem;

using Spectre.Console;

namespace LMS.DataAccess.Console;

public class WelcomeMenu
{
    private readonly PatronManager _patrons;
    private readonly StaffManager _staffs;
    private readonly BorrowManager _borrows;
    private readonly BookRepository _books;
    private readonly FineManager _fines;

    public WelcomeMenu(PatronManager patrons, StaffManager staffs, BorrowManager borrows, BookRepository books, FineManager fines)
    {
        _patrons = patrons;
        _staffs = staffs;
        _borrows = borrows;
        _books = books;
        _fines = fines;
    }

    public void ShowMenu()
    {
        while (true)
        {
            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[green]Welcome to the Library System[/]")
                    .PageSize(10)
                    .AddChoices(new[] { "Login", "Exit" }));

            switch (choice)
            {
                case "Login":
                    var login = new Login(_patrons, _staffs, _borrows, _books, _fines);
                    login.LoginMenu();
                    break;

                case "Exit":
                    AnsiConsole.MarkupLine("[yellow]Exiting the system. Goodbye![/]");
                    Environment.Exit(0);
                    break;

                default:
                    AnsiConsole.MarkupLine("[red]Invalid choice. Please try again.[/]");
                    break;
            }
        }
    }
}
