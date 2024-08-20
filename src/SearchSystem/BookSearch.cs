using BookSystem;
using System.Linq;

public class BookSearch
{
    private BookRepository _booksList;

    public BookSearch(BookRepository booksList)
    {
        _booksList = booksList;
    }

    public void SearchBookByTitle(string title)
    {
        List<Book> result = _booksList.GetBooksList()
            .Where(book => book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            .ToList();

        SearchResult(result);
    }

    public void SearchBookByAuthor(string author)
    {
        List<Book> result = _booksList.GetBooksList()
            .Where(book => book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            .ToList();

        SearchResult(result);
    }

    public void SearchBookByISBN(string isbn)
    {
        List<Book> result = _booksList.GetBooksList()
            .Where(book => book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
            .ToList();

        SearchResult(result);
    }

    public void SearchResult(List<Book> booksResult)
    {
        if (booksResult.Count == 0)
        {
            Console.WriteLine("No books found.");
        }
        else
        {
            foreach (Book book in booksResult)
            {
                book.BookDetails();
            }
        }
    }
}