using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.Services.Searchers;
using LMS.DataAccess.SearchSystem.BookSearchers.Concretes;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchByTitleInput : SearchInput
{
    BookRepository _books;
    public SearchByTitleInput(BookRepository _books)
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
            System.Console.WriteLine("Title cannot be null or empty.");
        }
    }
}
