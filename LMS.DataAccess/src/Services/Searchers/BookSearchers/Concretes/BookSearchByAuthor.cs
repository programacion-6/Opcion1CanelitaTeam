using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Services.Searchers.BookSearchers.Abstracts;
using LMS.DataAccess.Systems.Entities;

namespace LMS.DataAccess.SearchSystem.BookSearchers.Concretes;

public class BookSearchByAuthor : BookSearchTemplate<string>
{
    public BookSearchByAuthor(BookRepository bookManager) : base(bookManager)
    {
    }

    protected override List<Book> Search(string author)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetAllBooks())
        {
            if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
