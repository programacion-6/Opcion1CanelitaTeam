using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Interfaces;
using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;
using LMS.DataAccess.UserSystem.Concretes;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Concretes;

public class MakeBorrow : BorrowInput
{
    BookRepository Books;
    Patron Patron;
    BorrowManager Borrows;

    public MakeBorrow(BookRepository Books, Patron Patron, BorrowManager Borrows)
    {
        this.Books = Books;
        this.Patron = Patron;
        this.Borrows = Borrows;
    }
    public void BorrowOption()
    {
        AnsiConsole.Clear();
        System.Console.WriteLine("Enter the title of the book to borrow: ");
        string? bookTitle = System.Console.ReadLine();

        if (bookTitle != null)
        {
            Book book = (Book) PerformFind.Execute(new FindBookByTitle(Books, bookTitle));

            if (book != null)
            {
                DateTime BorrowDate = DateTime.Now;
                DateTime DueDate = BorrowDate.AddMonths(1);
                book.DecreaseStock();

                Borrows.AddBorrow(Patron, book, BorrowDate, DueDate);
            }
            else
            {
                System.Console.WriteLine($"There is no book with {bookTitle} Title");
            }
        }
    }
}
