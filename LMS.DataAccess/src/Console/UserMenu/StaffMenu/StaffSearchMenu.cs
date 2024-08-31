using LMS.DataAccess.Console.UserMenu.PatronMenu.Search;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;
using LMS.DataAccess.Systems.Concretes.Managers;


using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu;

public class StaffSearchMenu
{
    private readonly BookManager _books;
    private readonly PatronManager _patrons;

    public StaffSearchMenu(BookManager books, PatronManager patrons)
    {
        _books = books;
        _patrons = patrons;
    }

    public void ShowSearchMenu()
    {
        while (true)
        {
            AnsiConsole.Clear();
            var options = new[]
            {
                "Search book by Title",
                "Search book by Author",
                "Search book by ISBN",
                "Search patron by Name",
                "Search patron by Membership Number",
                "Exit"
            };

            var selectedOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Search Menu")
                    .AddChoices(options)
            );

            var search = new OptionSearch();

            switch (selectedOption)
            {
                case "Search book by Title":
                    search.SetSearchOption(new SearchByTitleInput(_books));
                    search.Execute();
                    Pause();
                    break;

                case "Search book by Author":
                    search.SetSearchOption(new SearchByAuthorInput(_books));
                    search.Execute();
                    Pause();
                    break;

                case "Search book by ISBN":
                    search.SetSearchOption(new SearchByISBNInput(_books));
                    search.Execute();
                    Pause();
                    break;

                case "Search patron by Name":
                    search.SetSearchOption(new SearchPatronByNameInput(_patrons));
                    search.Execute();
                    Pause();
                    break;

                case "Search patron by Membership Number":
                    search.SetSearchOption(new SearchPatronByMembershipNumberInput(_patrons));
                    search.Execute();
                    Pause();
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
    private void Pause()
    {
        AnsiConsole.MarkupLine("[gray]Press any key to continue...[/]");
        System.Console.ReadKey(true);
        AnsiConsole.Clear();
    }
}
