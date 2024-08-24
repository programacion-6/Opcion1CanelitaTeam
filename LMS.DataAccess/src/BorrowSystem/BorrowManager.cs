using BookSystem;
using Core.Exceptions;
using Core.Handlers;
using userSystem.Concrete;

namespace BorrowSystem;

public class BorrowManager
{
    List<Borrow> Borrows;
    private readonly ILogService _logService;

    public BorrowManager(List<Borrow> borrows)
    {
        Borrows = borrows;
        _logService = new LogService();
    }

    public void AddBorrow(Patron patron, Book book, DateTime borrowDate, DateTime dueDate)
    {
        try
        {
            if (borrowDate > dueDate)
            {
                throw new InvalidDateRangeException("Borrow date cannot be after due date.");
            }
            
            Borrow borrow = new Borrow(patron, book, borrowDate, dueDate);
            Borrows.Add(borrow);
            Console.WriteLine($"Successful Borrow of {book.Title} by {patron.getName()}"); 
        }
        catch (InvalidDateRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while adding a borrow.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }

    public void RemoveBorrow(string patronName, string bookTitle)
    {
        try
        {
            Borrow? borrow = FindBorrow(patronName, bookTitle);

            if (borrow == null)
            {
                throw new BorrowNotFoundException($"No borrow record found for {patronName} and {bookTitle}.");
            }

            Borrows.Remove(borrow);
        }
        catch (BorrowNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while adding a borrow.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
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

    public void ActiveBorrowsFromPatron(Patron patron)
    {
        try
        {
            Console.WriteLine("LIST OF NOT RETURNED BORROWS");

            bool hasActiveBorrows = false;
            foreach (Borrow borrow in Borrows)
            {
                if (borrow.GetPatron().getName().Equals(patron.getName()) && borrow.GetDelivered() == false)
                {
                    borrow.BorrowDetails();
                    hasActiveBorrows = true;
                }
            }

            if (!hasActiveBorrows)
            {
                throw new BorrowNotFoundException($"No active borrows found for {patron.getName()}.");
            }
        }
        catch (BorrowNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while listing active borrows.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }
    public List<Borrow> GetBorrows() => Borrows;
}
