using BookSystem;
using Core.Exceptions;
using userSystem.Concrete;

namespace BorrowSystem;

public class BorrowManager
{
    List<Borrow> Borrows;

    public BorrowManager(List<Borrow> borrows){
        Borrows = borrows;
    }

    public void AddBorrow(Patron patron, Book book, DateTime borrowDate, DateTime dueDate)
    {
        if (borrowDate > dueDate)
        {
            throw new InvalidDateRangeException("Borrow date cannot be after due date.");
        }
        
        Borrow borrow = new Borrow(patron, book, borrowDate, dueDate);
        Borrows.Add(borrow);
    }

    public void RemoveBorrow(string patronName, string bookTitle)
    {
        Borrow? borrow = FindBorrow(patronName, bookTitle);
        Borrows.Remove(borrow);
    }

    public Borrow? FindBorrow(string patronName, string bookTitle )
    {
        foreach (Borrow borrow in Borrows)
        {
            string currentPatron = borrow.GetPatron().getName();
            string currentBook = borrow.GetBook().Title;

            if (currentPatron == patronName && currentBook == bookTitle)
            {
                return borrow;
            }
        }

        return null;        
    }

    public void ActiveBorrowsFromPatron(Patron patron){
        Console.WriteLine("LIST OF NOT RETURNED BORROWS");

        foreach (Borrow borrow in Borrows)
        {
            if (borrow.GetPatron().getName().Equals(patron.getName()) && borrow.GetDelivered() == false)
            {
                borrow.BorrowDetails();
            }
        }
    }
    public List<Borrow> GetBorrows() => Borrows;
}
