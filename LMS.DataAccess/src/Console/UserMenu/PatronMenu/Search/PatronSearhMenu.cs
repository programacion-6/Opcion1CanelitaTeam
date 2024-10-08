using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;
using LMS.DataAccess.Systems.Concretes.Managers;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search;

public class PatronSearchMenu
{
    private readonly BookManager _books;

    public PatronSearchMenu(BookManager books)
    {
        _books = books;
    }

    public void PatronSearchMenuOptions()
    {
        while (true)
        {
            var options = new[]
            {
                "Search by Title",
                "Search by Author",
                "Search by ISBN",
                "Exit"
            };

            var selectedOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Books Search Menu")
                    .AddChoices(options)
            );

            OptionSearch optionSearch = new OptionSearch();

            switch (selectedOption)
            {
                case "Search by Title":
                    optionSearch.SetSearchOption(new SearchByTitleInput(_books));
                    optionSearch.Execute();
                    Pause();
                    break;

                case "Search by Author":
                    optionSearch.SetSearchOption(new SearchByAuthorInput(_books));
                    optionSearch.Execute();
                    Pause();
                    break;

                case "Search by ISBN":
                    optionSearch.SetSearchOption(new SearchByISBNInput(_books));
                    optionSearch.Execute();
                    Pause();
                    break;

                case "Exit":
                    System.Console.WriteLine("Exiting to main menu.");
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
