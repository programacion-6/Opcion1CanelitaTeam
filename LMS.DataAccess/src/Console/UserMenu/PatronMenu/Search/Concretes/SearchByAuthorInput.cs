using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem.BookSearchers.Concretes;
using LMS.DataAccess.Services.Searchers;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchByAuthorInput : SearchInput
{
    BookRepository _books;
    public SearchByAuthorInput(BookRepository _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        System.Console.Write("Enter the author of the book: ");
        string? author = System.Console.ReadLine();
        if (!string.IsNullOrEmpty(author))
        {
            PerformSearch.Search(new BookSearchByAuthor(_books), author);
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Author cannot be null or empty."));
        }
    }
}
