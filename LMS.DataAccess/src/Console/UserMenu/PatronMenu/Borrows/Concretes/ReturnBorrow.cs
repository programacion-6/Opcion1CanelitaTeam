using LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Interfaces;
using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Entities.Borrowing;
using LMS.DataAccess.Systems.Entities.User;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Concretes;

public class ReturnBorrow : BorrowInput
{
    Patron Patron;
    BorrowManager Borrows;
    BookRepository Books;
    FineManager Fines;

    public ReturnBorrow(Patron patron, BorrowManager borrows, BookRepository books, FineManager fines)
    {
        this.Patron = patron;
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    public void BorrowOption()
    {
        AnsiConsole.Clear();
        Borrows.ActiveBorrowsFromPatron(Patron);
        System.Console.WriteLine("Enter the title of the book to return: ");

        string? bookTitle = System.Console.ReadLine();

        if (bookTitle != null)
        {

            Borrow borrow = (Borrow) PerformFind.Execute(new FindBorrow(Borrows, Patron.getName(), bookTitle));

            if (borrow != null)
            {
                borrow.ReturnBook();
                ((Book) PerformFind.Execute(new FindBookByTitle(Books, bookTitle))).IncreaseStock();
                System.Console.WriteLine($"Succesfull returned {bookTitle}");
                if (DateTime.Now > borrow.GetDueDate())
                {
                    Fine currentFine = new Fine(borrow);
                    Fines.AddFine(currentFine);
                    System.Console.WriteLine($"A Fine was created because DueDate was {borrow.GetDueDate()} and was returned on {DateTime.Now}");
                    currentFine.FineDetails();
                }
            }
            else
            {
                System.Console.WriteLine($"User {Patron.getName()} dont have a borrow with this title");
            }
        }
    }
}
