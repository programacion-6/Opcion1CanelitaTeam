
using LMS.DataAccess.Services.Validators;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Interfaces;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class BookRepository : IBookRepository
{
    private List<Book> _books;
    private BookValidator _validator;

    public BookRepository()
    {
        _books = new List<Book>();
        _validator = new BookValidator();
    }

    public void AddBook(Book book)
    {
        if (_validator.ValidateBook(book))
        {
            _books.Add(book);
        }
        else
        {
            System.Console.WriteLine("[ERROR] Book cannot be added. Invalid data.");
        }
    }

    public void UpdateBook(string title, string? newTitle = null, string? newAuthor = null, string? newGenre = null, DateTime? newPublicationDate = null, int? newStock = null)
    {
        Book? bookToUpdate = _books.Find(b => b.Title == title);

        if (bookToUpdate == null)
        {
            System.Console.WriteLine($"[ERROR] Book with title '{title}' not found.");
            return;
        }

        if (_validator.ValidateUpdateParameters(title, newTitle, newAuthor, newGenre, newStock))
        {
            bookToUpdate.Title = newTitle ?? bookToUpdate.Title;
            bookToUpdate.Author = newAuthor ?? bookToUpdate.Author;
            bookToUpdate.Genre = newGenre ?? bookToUpdate.Genre;
            bookToUpdate.PublicationDate = newPublicationDate ?? bookToUpdate.PublicationDate;
            bookToUpdate.Stock = newStock ?? bookToUpdate.Stock;

            System.Console.WriteLine($"[INFO] Book '{title}' has been updated.");
        }
        else
        {
            System.Console.WriteLine($"[ERROR] Book with title '{title}' cannot be updated. Invalid data.");
        }
    }

    public void RemoveBook(string title)
    {
        if (_validator.ValidateTitle(title))
        {
            Book? bookToRemove = _books.Find(b => b.Title == title);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
        }
        else
        {
            System.Console.WriteLine($"[ERROR] Book with title '{title}' cannot be removed. Invalid title.");
        }
    }

    public void ListBooksByGenre(string genre)
    {
        if (_validator.ValidateGenre(genre))
        {
            List<Book> booksInGenre = _books.FindAll(b => b.Genre == genre);
            foreach (Book book in booksInGenre)
            {
                book.BookDetails();
            }
        }
        else
        {
            System.Console.WriteLine($"[ERROR] No books found in the genre '{genre}'. Invalid genre.");
        }
    }

    public bool CheckAvailability(string title)
    {        
        return _validator.ValidateTitle(title) && _books.Find(b => b.Title == title)?.Stock > 0;
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
