using BookSystem;
public class BookSearchByISBN : BookSearchTemplate <string>
{
    public BookSearchByISBN(BookRepository bookManager) : base(bookManager) { }

    protected override List<Book> Search(string isbn)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetBooksList())
        {
            if (book.ISBN.Equals(isbn, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
