
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Services.Validators;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Interfaces;

using Spectre.Console;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class BookManager : IBaseManager<Book>
{
    private List<Book> _books;
    private BookValidator _validator;

    public BookManager()
    {
        _books = new List<Book>();
        _validator = new BookValidator();
    }

    public bool Add(Book book)
    {
        if (_validator.ValidateBook(book))
        {
            _books.Add(book);
            return true;
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Book cannot be added. Invalid data."));
            return false;
        }
    }

    public bool Update(Book book)
    {
        Book? bookToUpdate = _books.Find(b => b.ISBN.Equals(book.ISBN, StringComparison.OrdinalIgnoreCase));

        if (bookToUpdate == null)
        {
            AnsiConsole.WriteLine("[gray] Book not found.");
            Pause();
            return false;
        }

        if (_validator.ValidateUpdateParameters(book))
        {
            bookToUpdate.Title = book.Title ?? bookToUpdate.Title;
            bookToUpdate.Author = book.Author ?? bookToUpdate.Author;
            bookToUpdate.Genre = book.Genre ?? bookToUpdate.Genre;
            if (book.PublicationDate <= DateTime.Now) bookToUpdate.PublicationDate = book.PublicationDate;
            bookToUpdate.Stock = book.Stock > 0 ? book.Stock : bookToUpdate.Stock;

            System.Console.WriteLine($"[INFO] Book '{bookToUpdate.Title}' has been updated.");
            Pause();
            return true;
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException($"Book with title '{bookToUpdate.Title}' cannot be updated. Invalid data."));
            Pause();
            return false;
        }
    }

    public bool Remove(Book book)
    {
        if (_books.Remove(book))
        {
            AnsiConsole.WriteLine("[green] Book removed successfully");
            Pause();
            return true;
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Book cannot be removed. Invalid data."));
            return false;
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

    public List<Book> GetAll()
    {
        return _books;
    }

    private void Pause()
    {
        AnsiConsole.MarkupLine("[gray]Press any key to continue...[/]");
        System.Console.ReadKey(true);
        AnsiConsole.Clear();
    }
}
