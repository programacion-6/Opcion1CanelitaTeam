using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem.BookSearchers.Concretes;
using LMS.DataAccess.Services.Searchers;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchByISBNInput : SearchInput
{
    BookManager _books;
    public SearchByISBNInput(BookManager _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        System.Console.Write("Enter the ISBN of the book: ");
        string? isbn = System.Console.ReadLine();
        if (!string.IsNullOrEmpty(isbn))
        {
            PerformSearch.Search(new BookSearchByISBN(_books), isbn);
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("ISBN cannot be null or empty."));
        }
    }
}
