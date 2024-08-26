using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem;
using LMS.DataAccess.SearchSystem.BookSearch.Concretes;

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
