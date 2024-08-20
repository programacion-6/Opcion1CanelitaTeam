using BookSystem;
public class BookSearchByAuthor : BookSearchTemplate <string>
{
    public BookSearchByAuthor(BookRepository bookManager) : base(bookManager) 
    { 
    }

    protected override List<Book> Search(string author)
    {
        List<Book> result = new List<Book>();
        foreach (Book book in Repository.GetBooksList())
        {
            if (book.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(book);
            }
        }
        return result;
    }
}
