using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Interfaces;
using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;

using Spectre.Console;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Concretes;

public class AddUpdateInput : BookInput
{
    private readonly BookManager _books;

    public AddUpdateInput(BookManager books)
    {
        _books = books;
    }

    public void BookOption()
    {
        var isbn = AnsiConsole.Prompt(new TextPrompt<string>("Enter the isbn of the book to update:"));

        Book? book = _books.GetAll().Find(book => book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));

        if (book != null)
        {
            var newTitle = AnsiConsole.Prompt(new TextPrompt<string>("Enter the new title of the book (leave blank to keep current):")
                .DefaultValue(book.Title));
            var newAuthor = AnsiConsole.Prompt(new TextPrompt<string>("Enter the new author of the book (leave blank to keep current):")
                .DefaultValue(book.Author));
            var newGenre = AnsiConsole.Prompt(new TextPrompt<string>("Enter the new genre of the book (leave blank to keep current):")
                .DefaultValue(book.Genre));
            var newDateInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the new publication date (yyyy-MM-dd) of the book (leave blank to keep current):")
                .DefaultValue(book.PublicationDate.ToString("yyyy-MM-dd")));

            var newStockInput = AnsiConsole.Prompt(new TextPrompt<string>("Enter the new stock (leave blank to keep current):")
                .DefaultValue(book.Stock.ToString()));

            int newStock = int.TryParse(newStockInput, out int parsedStock) ? parsedStock : book.Stock;

            if (!DateTime.TryParse(newDateInput, out DateTime newPublicationDate))
            {
                newPublicationDate = book.PublicationDate;
            }
            Book newBook = new Book(newTitle, newAuthor, newGenre, newPublicationDate, book.ISBN) {Stock = newStock};

            _books.Update(newBook);

            AnsiConsole.MarkupLine("[green]Book updated successfully.[/]");
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Book not found"));
        }
    }
}
