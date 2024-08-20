namespace BookSystem;
public class BookRepository : IBookRepository
{
    private List<Book> _books;

    public BookRepository()
    {
        _books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        _books.Add(book);
    }

    public void UpdateBook(string title, string? newTitle = null, string? newAuthor = null, string? newGenre = null, DateTime? newPublicationDate = null)
    {
        Book bookToUpdate = _books.Find(b => b.Title == title);
        if (bookToUpdate != null)
        {
            if (newTitle != null) bookToUpdate.Title = newTitle;
            if (newAuthor != null) bookToUpdate.Author = newAuthor;
            if (newGenre != null) bookToUpdate.Genre = newGenre;
            if (newPublicationDate != null) bookToUpdate.PublicationDate = newPublicationDate.Value;
        }
    }

    public void RemoveBook(string title)
    {
        Book bookToRemove = _books.Find(b => b.Title == title);
        if (bookToRemove != null)
        {
            _books.Remove(bookToRemove);
        }
    }

    public void ListBooksByGenre(string genre)
    {
        List<Book> booksInGenre = _books.FindAll(b => b.Genre == genre);
        foreach (Book book in booksInGenre)
        {
            book.BookDetails();
        }
    }

    public bool CheckAvailability(string title)
    {
        Book bookToCheck = _books.Find(b => b.Title == title);
        if (bookToCheck != null)
        {
            return bookToCheck.Stock > 0;
        }
        return false;
    }

    public Book? FoundBookByTitle(string title)
    {
        return _books.Find(b => b.Title == title);
    }

    public void AvailableBooks(){
        foreach (Book book in _books)
        {
            if (book.Stock > 0)
            {
                book.BookDetails();
            }
        }
    }

    public List<Book> GetBooksList()
    {
        return _books;
    }

    public void SetBooksList(List<Book> books)
    {
        _books = books;
    }
}
