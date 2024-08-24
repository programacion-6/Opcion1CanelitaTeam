using BookSystem;
using SearchSystem;

public class SearchByISBNInput : SearchInput
{
    BookRepository _books;
    public SearchByISBNInput (BookRepository _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        Console.Write("Enter the ISBN of the book: ");
        string? isbn = Console.ReadLine();
        if (!string.IsNullOrEmpty(isbn))
        {
            PerformSearch.Search(new BookSearchByISBN(_books), isbn);
        }
        else
        {
            Console.WriteLine("Title cannot be null or empty.");
        }
    }
}