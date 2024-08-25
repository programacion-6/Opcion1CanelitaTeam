using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search;

public class PatronSearchMenu
{
    private readonly BookRepository _books;

    public PatronSearchMenu(BookRepository books)
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
                    break;

                case "Search by Author":
                    optionSearch.SetSearchOption(new SearchByAuthorInput(_books));
                    optionSearch.Execute();
                    break;

                case "Search by ISBN":
                    optionSearch.SetSearchOption(new SearchByISBNInput(_books));
                    optionSearch.Execute();
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
}
