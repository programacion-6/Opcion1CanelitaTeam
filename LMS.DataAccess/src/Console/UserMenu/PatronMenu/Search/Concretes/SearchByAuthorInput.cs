using BookSystem;
using SearchSystem;

public class SearchByAuthorInput : SearchInput
{
    BookRepository _books;
    public SearchByAuthorInput (BookRepository _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        Console.Write("Enter the author of the book: ");
        string? author = Console.ReadLine();
        if (!string.IsNullOrEmpty(author))
        {
            PerformSearch.Search(new BookSearchByAuthor(_books), author);    
        }
        else
        {
            Console.WriteLine("Title cannot be null or empty.");
        }
    }
}