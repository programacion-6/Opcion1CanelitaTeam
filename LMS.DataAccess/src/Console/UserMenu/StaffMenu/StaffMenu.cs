using LMS.DataAccess.Console.UserMenu.StaffMenu.Books;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Report;
using LMS.DataAccess.Console.Utils.ItemsList;
using LMS.DataAccess.Console.Utils.ItemsList.Concretes;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu;

public class StaffMenu : UserMenuTemplate
{
    private readonly Staff _staff;
    private readonly PatronManager _patrons;

    public StaffMenu(Staff staff, BorrowManager borrows, BookRepository books, PatronManager patrons, FineManager fines)
        : base(borrows, books, fines)
    {
        _staff = staff;
        _patrons = patrons;
    }

    public override void UserMenu()
    {
        var options = new List<string>
        {
            "User details",
            "Book Management",
            "Report Management",
            "Search Tool",
            "Books List",
            "Patron List",
            "Exit"
        };

        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Markup($"[bold]Welcome {_staff.getName()}[/]\n"));
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select an option:")
                    .AddChoices(options)
                );

            ListAction page = new ListAction();

            switch (selection)
            {
                case "User details":
                    _staff.UserInformation();
                    AnsiConsole.MarkupLine("[yellow]Press any key to return to the menu...[/]");
                    System.Console.ReadKey();
                    break;
                case "Book Management":
                    var bookManagement = new BookStaffManagement(_books);
                    bookManagement.BookStaffMenu();
                    break;
                case "Report Management":
                    var reportMenu = new ReportStaffMenu(_borrows, _fines);
                    reportMenu.ReportMenu();
                    break;
                case "Search Tool":
                    var searchMenu = new StaffSearchMenu(_books, _patrons);
                    searchMenu.ShowSearchMenu();
                    break;
                case "Books List":
                    page.setPagination(new BookPagination(_books.GetAllBooks()));
                    page.Execute();
                    break;
                case "Patron List":
                    page.setPagination(new PatronPagination(_patrons.GetPatrons()));
                    page.Execute();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[green]Exiting the system. Goodbye![/]");
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid selection. Please try again.[/]");
                    break;
            }
        }
    }
}
