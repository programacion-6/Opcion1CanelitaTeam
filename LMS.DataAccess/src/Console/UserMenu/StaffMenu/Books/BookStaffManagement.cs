using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Concretes;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Books;

public class BookStaffManagement
{
    private readonly BookRepository _books;

    public BookStaffManagement(BookRepository books)
    {
        _books = books;
    }

    public void BookStaffMenu()
    {
        var options = new List<string> { "Add Book", "Update Book", "Remove Book", "Exit" };

        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Markup("[bold]Book Staff Management Menu[/]\n"));
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select an option:")
                    .AddChoices(options)
            );

            BookAction bookOption = new BookAction();

            switch (selection)
            {
                case "Add Book":
                    bookOption.setBookInput(new AddBookInput(_books));
                    bookOption.Execute();
                    break;
                case "Update Book":
                    bookOption.setBookInput(new AddUpdateInput(_books));
                    bookOption.Execute();
                    break;
                case "Remove Book":
                    bookOption.setBookInput(new AddRemoveInput(_books));
                    bookOption.Execute();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[green]Exiting to main menu.[/]");
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid selection. Please try again.[/]");
                    break;
            }
        }
    }
}
