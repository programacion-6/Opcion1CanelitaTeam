using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem.BookSearchers.Concretes;
using LMS.DataAccess.Services.Searchers;

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
            System.Console.WriteLine("Title cannot be null or empty.");
        }
    }
}
