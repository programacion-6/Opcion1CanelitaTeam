using BookSystem;

public class FindBookByTitle : FindProcess
{
    BookRepository Books;
    string Criteria;
    public FindBookByTitle (BookRepository Books, string criteria)
    {
        this.Books = Books;
        this.Criteria = criteria;
    }
    public Object FindItem()
    {
        var book = Books.GetBooksList().Find(b => b.Title == Criteria);
        if (book == null)
        {
            throw new InvalidOperationException($"No book found with title: {Criteria}");
        }
        return book;
    }
}