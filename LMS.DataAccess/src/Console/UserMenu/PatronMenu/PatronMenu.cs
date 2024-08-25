using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search;
using LMS.DataAccess.Console.Utils.ItemsList;
using LMS.DataAccess.Console.Utils.ItemsList.Concretes;
using LMS.DataAccess.FineSystem;
using LMS.DataAccess.UserSystem.Concretes;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu;

public class PatronMenu : UserMenuTemplate
{
    private readonly Patron _patron;

    public PatronMenu(Patron patron, BorrowManager borrows, BookRepository books, FineManager fines)
        : base(borrows, books, fines)
    {
        _patron = patron;
    }

    public override void UserMenu()
    {
        while (true)
        {
            var options = new[]
            {
                "User details",
                "Borrow Options",
                "Search Tool",
                "Books List",
                "Exit"
            };

            var selectedOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title($"Welcome {_patron.getName()}")
                    .AddChoices(options)
                );

            ListAction page = new ListAction();

            switch (selectedOption)
            {
                case "User details":
                    _patron.UserInformation();
                    AnsiConsole.MarkupLine("[yellow]Press any key to return to the menu...[/]");
                    System.Console.ReadKey();
                    break;

                case "Borrow Options":
                    var borrowMenu = new PatronsBorrowMenu(_borrows, _patron, _books, _fines);
                    borrowMenu.PatronBooksMenu();
                    break;

                case "Search Tool":
                    var searchMenu = new PatronSearchMenu(_books);
                    searchMenu.PatronSearchMenuOptions();
                    break;

                case "Books List":
                    page.setPagination(new BookPagination(_books.GetBooksList()));
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
