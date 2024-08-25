using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.SearchSystem.BookSearch.Abstract;

namespace LMS.DataAccess.SearchSystem.BookSearch.Concretes;

public class BookSearchByISBN : BookSearchTemplate <string>
{
    public BookSearchByISBN(BookRepository bookManager) : base(bookManager) { }

    protected override List<Book> Search(string isbn)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetBooksList())
        {
            if (book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
