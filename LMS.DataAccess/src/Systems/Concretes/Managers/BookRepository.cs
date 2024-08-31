
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
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
            ErrorHandler.HandleError(new InvalidInputException("Book cannot be added. Invalid data."));
        }
    }

    public void UpdateBook(string isbn, Book book)
    {
        Book? bookToUpdate = _books.Find(b => b.ISBN == isbn);

        if (bookToUpdate == null)
        {
            System.Console.WriteLine("[ERROR] Book not found.");
            return;
        }

        if (_validator.ValidateUpdateParameters(book))
        {
            bookToUpdate.Title = book.Title ?? bookToUpdate.Title;
            bookToUpdate.Author = book.Author ?? bookToUpdate.Author;
            bookToUpdate.Genre = book.Genre ?? bookToUpdate.Genre;
            if (book.PublicationDate <= DateTime.Now) bookToUpdate.PublicationDate = book.PublicationDate;
            bookToUpdate.Stock = book.Stock <= 0 ? book.Stock : bookToUpdate.Stock;

            System.Console.WriteLine($"[INFO] Book '{bookToUpdate.Title}' has been updated.");
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException($"Book with title '{bookToUpdate.Title}' cannot be updated. Invalid data."));
        }
    }

    public void RemoveBook(string isbn)
    {
        if (_validator.ValidateTitle(isbn))
        {
            Book? bookToRemove = _books.Find(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
        }
        else
        {
            System.Console.WriteLine($"[ERROR] Book cannot be removed. Invalid isbn.");
            ErrorHandler.HandleError(new InvalidInputException("Book cannot be removed. Invalid data."));
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
            ErrorHandler.HandleError(new InvalidInputException($"No books found in the genre '{genre}'. Invalid genre."));
        }
    }

    public bool CheckAvailability(string title)
    {        
        return _validator.ValidateTitle(title) && _books.Find(b => b.Title == title)?.Stock > 0;
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }
}
