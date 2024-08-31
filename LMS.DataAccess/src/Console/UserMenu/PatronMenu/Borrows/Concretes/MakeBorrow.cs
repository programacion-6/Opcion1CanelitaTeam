using LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Interfaces;
using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Entities.Borrowing;
using LMS.DataAccess.Systems.Entities.User;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Concretes;

public class MakeBorrow : BorrowInput
{
    BookManager Books;
    Patron Patron;
    BorrowManager Borrows;

    public MakeBorrow(BookManager Books, Patron Patron, BorrowManager Borrows)
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
                if (book.Stock > 0)
                {
                    DateTime BorrowDate = DateTime.Now;
                    DateTime DueDate = BorrowDate.AddMonths(1);
                    book.DecreaseStock();

                    Borrow borrow = new Borrow(Patron, book, BorrowDate, DueDate);
                    Borrows.Add(borrow);
                }
                else
                {
                    AnsiConsole.MarkupLine("[yellow] Book is out of stock. [/]");
                }
            }
        }
    }
}
