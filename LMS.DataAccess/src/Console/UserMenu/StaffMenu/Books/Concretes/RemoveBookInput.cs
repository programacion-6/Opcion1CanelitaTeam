using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Interfaces;

using Spectre.Console;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Concretes;

public class AddRemoveInput : BookInput
{
    private readonly BookRepository _books;

    public AddRemoveInput(BookRepository books)
    {
        _books = books;
    }

    public void BookOption()
    {
        var title = AnsiConsole.Prompt(new TextPrompt<string>("Enter the isbn of the book to remove:"));
        if (title != null)
        {
            _books.RemoveBook(title);
            AnsiConsole.MarkupLine("[green]Book removed successfully.[/]");
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Invalid isbn, please enter a valid input"));
        }
        
    }
}
