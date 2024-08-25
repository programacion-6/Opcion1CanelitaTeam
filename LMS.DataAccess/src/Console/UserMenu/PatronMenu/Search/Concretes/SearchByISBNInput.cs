using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem;
using LMS.DataAccess.SearchSystem.BookSearch.Concretes;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchByISBNInput : SearchInput
{
    BookRepository _books;
    public SearchByISBNInput (BookRepository _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        Console.Write("Enter the ISBN of the book: ");
        string? isbn = Console.ReadLine();
        if (!string.IsNullOrEmpty(isbn))
        {
            PerformSearch.Search(new BookSearchByISBN(_books), isbn);
        }
        else
        {
            Console.WriteLine("Title cannot be null or empty.");
        }
    }
}