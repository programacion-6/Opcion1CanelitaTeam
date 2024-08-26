using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.SearchSystem.BookSearch.Abstract;

namespace LMS.DataAccess.SearchSystem.BookSearch.Concretes;

public class BookSearchByAuthor : BookSearchTemplate<string>
{
    public BookSearchByAuthor(BookRepository bookManager) : base(bookManager)
    {
    }

    protected override List<Book> Search(string author)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetBooksList())
        {
            if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
