using BookSystem;
public class BookSearchByTitle : BookSearchTemplate <string>
{
    public BookSearchByTitle(BookRepository bookManager) : base(bookManager) { }

    protected override List<Book> Search(string title)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetBooksList())
        {
            if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}