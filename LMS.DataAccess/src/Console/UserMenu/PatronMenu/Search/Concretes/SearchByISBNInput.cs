using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem.BookSearchers.Concretes;
using LMS.DataAccess.Services.Searchers;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchByISBNInput : SearchInput
{
    BookRepository _books;
    public SearchByISBNInput(BookRepository _books)
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
            System.Console.WriteLine("Title cannot be null or empty.");
        }
    }
}
