using BookSystem;
using Spectre.Console;

public class AddRemoveInput : BookInput
{
    private readonly BookRepository _books;

    public AddRemoveInput(BookRepository books)
    {
        _books = books;
    }

    public void BookOption()
    {
        var title = AnsiConsole.Prompt(new TextPrompt<string>("Enter the title of the book to remove:"));
        _books.RemoveBook(title);
        AnsiConsole.MarkupLine("[green]Book removed successfully.[/]");
    }
}
