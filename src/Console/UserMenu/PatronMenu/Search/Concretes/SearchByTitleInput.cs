using BookSystem;
using SearchSystem;

public class SearchByTitleInput : SearchInput
{
    BookRepository _books;
    public SearchByTitleInput (BookRepository _books)
    {
        this._books = _books;
    }
    public void SearchByInput()
    {
        Console.Write("Enter the title of the book: ");
        string? title = Console.ReadLine();
        if (!string.IsNullOrEmpty(title))
        {
            PerformSearch.Search(new BookSearchByTitle(_books), title);
        }
        else
        {
            Console.WriteLine("Title cannot be null or empty.");
        }
    }
}