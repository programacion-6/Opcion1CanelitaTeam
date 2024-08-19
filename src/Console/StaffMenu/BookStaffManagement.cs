using System;
using System.Collections.Generic;
using BookSystem;
using LibraryConsole.Utils;

public class BookStaffManagement
{
    BookManager Books;

    public BookStaffManagement(BookManager books)
    {
        this.Books = books;
    }

    public void BookStaffMenu()
    {
        List<string> options = new List<string> { "Add Book", "Update Book", "Remove Book", "Exit" };

        while (true)
        {
            MenuGenerator.genericMenu("Book Staff Management Menu", options);
            Console.Write("Please select an option: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= options.Count)
            {
                switch (selectedIndex)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        UpdateBook();
                        break;
                    case 3:
                        RemoveBook();
                        break;
                    case 4:
                        Console.WriteLine("Exiting to main menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }
    }

    private void AddBook()
    {
        Console.Write("Enter the title of the book: ");
        string title = Console.ReadLine();
        Console.Write("Enter the author of the book: ");
        string author = Console.ReadLine();
        Console.Write("Enter the genre of the book: ");
        string genre = Console.ReadLine();
        Console.Write("Enter the publication date (yyyy-MM-dd) of the book: ");
        DateTime publicationDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter the ISBN of the book: ");
        string isbn = Console.ReadLine();
        Console.Write("Enter the stock of the book: ");
        string stockInput = Console.ReadLine();
        int stock = int.Parse(stockInput);
        Book newBook = new Book(title, author, genre, publicationDate, isbn);
        newBook.setStock(stock);
        Books.AddBook(newBook);

        Console.WriteLine("Book added successfully.");
    }

    private void UpdateBook()
    {
        Console.Write("Enter the title of the book to update: ");
        string title = Console.ReadLine();
        Book book = Books.FoundBookByTitle(title);

        if (book != null)
        {
            Console.Write("Enter the new title of the book (leave blank to keep current): ");
            string newtitle = Console.ReadLine();
            Console.Write("Enter the new author of the book (leave blank to keep current): ");
            string newauthor = Console.ReadLine();
            Console.Write("Enter the new genre of the book (leave blank to keep current): ");
            string newgenre = Console.ReadLine();
            Console.Write("Enter the new publication date (yyyy-MM-dd) of the book (leave blank to keep current): ");
            string newdateInput = Console.ReadLine();
            DateTime newPublicationDate;
            DateTime.TryParse(newdateInput, out newPublicationDate);
            

            Books.UpdateBook(title, newtitle, newauthor, newgenre, newPublicationDate);
            Console.WriteLine("Book updated successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    private void RemoveBook()
    {
        Console.Write("Enter the title of the book to remove: ");
        string title = Console.ReadLine();
        Books.RemoveBook(title);

    }
}
