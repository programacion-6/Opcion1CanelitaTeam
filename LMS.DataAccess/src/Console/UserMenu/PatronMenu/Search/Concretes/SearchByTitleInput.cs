using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.Services.Searchers;
using LMS.DataAccess.SearchSystem.BookSearchers.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchByTitleInput : SearchInput
{
    BookManager _books;
    public SearchByTitleInput(BookManager _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        System.Console.Write("Enter the title of the book: ");
        string? title = System.Console.ReadLine();
        if (!string.IsNullOrEmpty(title))
        {
            PerformSearch.Search(new BookSearchByTitle(_books), title);
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Title cannot be null or empty."));
        }
    }
}
