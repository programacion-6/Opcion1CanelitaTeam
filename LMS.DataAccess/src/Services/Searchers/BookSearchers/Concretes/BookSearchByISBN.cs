using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Services.Searchers.BookSearchers.Abstracts;
using LMS.DataAccess.Systems.Entities;

namespace LMS.DataAccess.SearchSystem.BookSearchers.Concretes;

public class BookSearchByISBN : BookSearchTemplate<string>
{
    public BookSearchByISBN(BookRepository bookManager) : base(bookManager) { }

    protected override List<Book> Search(string isbn)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetAllBooks())
        {
            if (book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
