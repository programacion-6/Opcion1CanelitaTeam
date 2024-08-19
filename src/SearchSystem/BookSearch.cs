using BookSystem;
using userSystem;
using userSystem.Concrete;

public class BookSearch{
    BookManager BooksList;
    public BookSearch(BookManager bookManager){
        this.BooksList = bookManager;
    }

    public void SearchBookByTitle(string title)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in BooksList.getBooksList())
        {
            if (book.getTitle().Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        SearchResult(result);
    }

    public void SearchBookByAuthor(string author)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in BooksList.getBooksList())
        {
            if (book.getAuthor().Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        SearchResult(result);
    }

    public void SearchBookByISBN(string isbn)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in BooksList.getBooksList())
        {
            if (book.getISBN().Equals(isbn, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        SearchResult(result);
    }

    public void SearchResult(List<Book> BooksResult)
    {
        foreach(Book book in BooksResult)
        {
            book.BookDetails();
        }
    }
    
}