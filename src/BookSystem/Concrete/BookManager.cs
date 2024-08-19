namespace BookSystem;

using Utils;
using System;
using System.Collections.Generic;

public class BookManager : BookManagement
{
    List<Book> BooksList { get; set; }

    public BookManager()
    {
        BooksList = new List<Book>();
    }

    public void AddBook(Book book)
    {
        string bookTitle = book.getTitle();
        if (FoundBookByTitle(bookTitle) == null)
        {
            BooksList.Add(book);
            Console.WriteLine($"Book with title '{book.getTitle()}' has been added.");
        }
        else
        {
            Console.WriteLine($"Book with title '{book.getTitle()}' already exists.");
        }
    }

    public void UpdateBook(string title, string? newTitle = null, string? newAuthor = null, string? newGenre = null, DateTime? newPublicationDate = null)
    {
        Book? book = FoundBookByTitle(title);
        if (book != null)
        {
            if (!string.IsNullOrEmpty(newTitle))
        {
                book.setTitle(newTitle);
        }
            if (!string.IsNullOrEmpty(newAuthor))
            {
                book.setAuthor(newAuthor);
            }
            if (!string.IsNullOrEmpty(newGenre))
            {
                book.setGenre(newGenre);
            }
            if (newPublicationDate.HasValue)
            {
                book.setPublicationDate(newPublicationDate.Value);
            }
            Console.WriteLine($"Book with title '{title}' has been updated.");
        }
        else
        {
            Console.WriteLine($"Book with title '{title}' not found.");
        }
    }

    public void RemoveBook(string title)
    {
        Book? book = FoundBookByTitle(title);
        if (book != null)
        {
            BooksList.Remove(book);
            Console.WriteLine($"Book with title '{title}' has been removed.");
        }
        else
        {
            Console.WriteLine($"Book with title '{title}' not found.");
        }
    }

    public void ListBooksByGenre(string genre)
    {
        var booksByGenre = BooksList.FindAll(book => book.getGenre().Equals(genre, StringComparison.OrdinalIgnoreCase));
        if (booksByGenre.Count > 0)
        {
            Console.WriteLine($"Books in genre '{genre}':");
            foreach (Book book in booksByGenre)
            {
                Console.WriteLine($"- {book.getTitle()} by {book.getAuthor()}");
            }
        }
        else
        {
            Console.WriteLine($"No books found in genre '{genre}'.");
        }
    }

    public bool CheckAvailability(string title)
    {
        bool availability = false;
        Book? book = FoundBookByTitle(title);
        if(book != null && book.getStock() > 0)
        {
            availability = true;
        }
        return availability;    
    }

    public Book? FoundBookByTitle(string title)
    {
        try
        {
            foreach (Book book in BooksList)
            {
                if (StringComparator.compare(book.getTitle(), title))
                {
                    return book;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while searching for the book: {ex.Message}");
        }

        return null;
    }

    public void AvailableBooks(){
        foreach(Book book in  BooksList){
            if(CheckAvailability(book.getTitle()))
            {
                book.BookDetails();
            }
        }
    }
    public List<Book> getBooksList() => BooksList;
    public void SetBooksList(List<Book> booksList) => this.BooksList = booksList;  
}
