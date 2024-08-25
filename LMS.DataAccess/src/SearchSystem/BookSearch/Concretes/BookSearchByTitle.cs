using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.SearchSystem.BookSearch.Abstract;

namespace LMS.DataAccess.SearchSystem.BookSearch.Concretes;

public class BookSearchByTitle : BookSearchTemplate <string>
{
    public BookSearchByTitle(BookRepository bookManager) : base(bookManager) { }

    protected override List<Book> Search(string title)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetBooksList())
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
