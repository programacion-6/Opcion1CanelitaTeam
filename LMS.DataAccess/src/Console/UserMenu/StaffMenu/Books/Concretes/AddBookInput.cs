using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Interfaces;

using Spectre.Console;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Concretes;

public class AddBookInput : BookInput
{
    private readonly BookManager _books;

    public AddBookInput(BookManager books)
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
        var isbn = Generator.GenerateISBN();
        var stockInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the stock of the book:"));
        int stock;
        while (!int.TryParse(stockInput, out stock))
        {
            ErrorHandler.HandleError(new InvalidInputException("Invalid stock quantity. Please enter a valid number."));
            stockInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the stock of the book:"));
        }

        var newBook = new Book(title, author, genre, publicationDate, isbn) { Stock = stock };
        _books.Add(newBook);

        AnsiConsole.MarkupLine("[green]Book added successfully.[/]");
    }
}
