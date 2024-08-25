using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.Core.Exceptions;

namespace LMS.DataAccess.SearchSystem.BookSearch.Abstract;

public abstract class BookSearchTemplate <T> : SearchBase<BookRepository, Book, T>
{
    public BookSearchTemplate (BookRepository bookManager) : base(bookManager) { }

    protected override void DisplayDetails(Book book)
    {
        book.BookDetails();
    }

    protected override void NoResultsFound()
    {
        throw new BookNotFoundException("No books found matching with the search criteria.");
    }

    protected abstract override List<Book> Search( T criterion);
}
