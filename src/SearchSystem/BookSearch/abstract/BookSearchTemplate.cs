using BookSystem;

public abstract class BookSearchTemplate <T> : SearchBase<BookRepository, Book, T>
{
    public BookSearchTemplate (BookRepository bookManager) : base(bookManager) { }

    protected override void DisplayDetails(Book book)
    {
        book.BookDetails();
    }

    protected override void NoResultsFound()
    {
        Console.WriteLine("No books found.");
    }

    protected abstract override List<Book> Search( T criterion);
}