using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem;
using LMS.DataAccess.SearchSystem.BookSearch.Concretes;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchByTitleInput : SearchInput
{
    BookRepository _books;
    public SearchByTitleInput (BookRepository _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        Console.Write("Enter the title of the book: ");
        string? title = Console.ReadLine();
        if (!string.IsNullOrEmpty(title))
        {
            PerformSearch.Search(new BookSearchByTitle(_books), title);
        }
        else
        {
            Console.WriteLine("Title cannot be null or empty.");
        }
    }
}