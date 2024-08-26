using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.BookSystem.Interfaces;

namespace LMS.DataAccess.BookSystem.Concretes;

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

    public void UpdateBook(string title, string? newTitle = null, string? newAuthor = null, string? newGenre = null, DateTime? newPublicationDate = null, int? newStock = null)
    {
        Book? bookToUpdate = _books.Find(b => b.Title == title);

        if (bookToUpdate == null)
        {
            System.Console.WriteLine($"[ERROR] Book with title '{title}' not found.");
            return;
        }

        if (newTitle != null) bookToUpdate.Title = newTitle;
        if (newAuthor != null) bookToUpdate.Author = newAuthor;
        if (newGenre != null) bookToUpdate.Genre = newGenre;
        if (newPublicationDate != null) bookToUpdate.PublicationDate = newPublicationDate.Value;
        if (newStock != null)
        {
            bookToUpdate.Stock = (int) newStock;
            System.Console.WriteLine($"[INFO] Stock updated to {newStock} for book '{title}'.");
        }
    }

    public void RemoveBook(string title)
    {
        Book? bookToRemove = _books.Find(b => b.Title == title);
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
        Book? bookToCheck = _books.Find(b => b.Title == title);
        if (bookToCheck != null)
        {
            return bookToCheck.Stock > 0;
        }
        return false;
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
