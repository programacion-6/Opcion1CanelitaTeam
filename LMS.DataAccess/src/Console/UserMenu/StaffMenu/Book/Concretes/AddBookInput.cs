using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Book.Interfaces;
using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Book.Concretes;

public class AddBookInput : BookInput
{
    private readonly BookRepository _books;

    public AddBookInput(BookRepository books)
    {
        _books = books;
    }

    public void BookOption()
    {
        var title = AnsiConsole.Prompt(new TextPrompt<string>("Enter the title of the book:"));
        var author = AnsiConsole.Prompt(new TextPrompt<string>("Enter the author of the book:"));
        var genre = AnsiConsole.Prompt(new TextPrompt<string>("Enter the genre of the book:"));
        var publicationDateInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the publication date (yyyy-MM-dd) of the book:"));
        DateTime publicationDate;
        while (!DateTime.TryParse(publicationDateInput, out publicationDate))
        {
            AnsiConsole.MarkupLine("[red]Invalid date format. Please use yyyy-MM-dd.[/]");
            publicationDateInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the publication date (yyyy-MM-dd) of the book:"));
        }
        var isbn = AnsiConsole.Prompt(new TextPrompt<string>("Enter the ISBN of the book:"));
        var stockInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the stock of the book:"));
        int stock;
        while (!int.TryParse(stockInput, out stock))
        {
            AnsiConsole.MarkupLine("[red]Invalid stock quantity. Please enter a valid number.[/]");
            stockInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the stock of the book:"));
        }

        var newBook = new Book(title, author, genre, publicationDate, isbn) { Stock = stock };
        _books.AddBook(newBook);

        AnsiConsole.MarkupLine("[green]Book added successfully.[/]");
    }
}
