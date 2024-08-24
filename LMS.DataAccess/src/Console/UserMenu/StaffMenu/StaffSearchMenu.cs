using BookSystem;
using userSystem;
using Spectre.Console;

public class StaffSearchMenu
{
    private readonly BookRepository _books;
    private readonly PatronManager _patrons;

    public StaffSearchMenu(BookRepository books, PatronManager patrons)
    {
        _books = books;
        _patrons = patrons;
    }

    public void ShowSearchMenu()
    {
        while (true)
        {
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

            var search = new SearchOption();

            switch (selectedOption)
            {
                case "Search book by Title":
                    search.SetSearchOption(new SearchByTitleInput(_books));
                    search.Execute();
                    break;

                case "Search book by Author":
                    search.SetSearchOption(new SearchByAuthorInput(_books));
                    search.Execute();
                    break;

                case "Search book by ISBN":
                    search.SetSearchOption(new SearchByISBNInput(_books));
                    search.Execute();
                    break;

                case "Search patron by Name":
                    search.SetSearchOption(new SearchPatronByNameInput(_patrons));
                    search.Execute();
                    break;

                case "Search patron by Membership Number":
                    search.SetSearchOption(new SearchPatronByMembershipNumberInput(_patrons));
                    search.Execute();
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
