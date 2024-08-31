using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Interfaces;

using Spectre.Console;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Concretes;

public class AddRemoveInput : BookInput
{
    private readonly BookManager _books;

    public AddRemoveInput(BookManager books)
    {
        _books = books;
    }

    public void BookOption()
    {
        var isbn = AnsiConsole.Prompt(new TextPrompt<string>("Enter the isbn of the book to remove:"));
        var book = _books.GetAll().Find(book => book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            _books.Remove(book);
            AnsiConsole.MarkupLine("[green]Book removed successfully.[/]");
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Invalid isbn, please enter a valid input"));
        }
    }
}
