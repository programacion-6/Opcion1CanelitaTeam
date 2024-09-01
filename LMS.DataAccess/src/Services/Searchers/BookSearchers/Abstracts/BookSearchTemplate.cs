using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Services.Searchers.BookSearchers.Abstracts;

public abstract class BookSearchTemplate<T> : SearchBase<BookManager, Book, T>
{
    public BookSearchTemplate(BookManager bookManager) : base(bookManager) { }

    protected override void DisplayDetails(Book book)
    {
        book.BookDetails();
    }

    protected override void NoResultsFound()
    {
        ErrorHandler.HandleError(new BookNotFoundException("No books found matching with the search criteria."));
    }

    protected abstract override List<Book> Search(T criterion);
}
