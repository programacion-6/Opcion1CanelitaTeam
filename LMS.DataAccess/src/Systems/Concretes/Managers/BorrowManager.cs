using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Services.Validators;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Entities.Borrowing;
using LMS.DataAccess.Systems.Entities.User;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class BorrowManager
{
    List<Borrow> Borrows;
    private readonly ILogService _logService;
    private BorrowValidator _borrowValidator;

    public BorrowManager()
    {
        Borrows = new List<Borrow>();
        _logService = new LogService();
        _borrowValidator = new BorrowValidator();
    }

    public void AddBorrow(Borrow borrow)
    {

        if (_borrowValidator.ValidateBorrow(borrow))
        {
            Borrows.Add(borrow);
            System.Console.WriteLine($"Successful Borrow of {borrow.GetBook().Title} by {borrow.GetPatron().getName()}");
        }
        else
        {
            System.Console.WriteLine($"Cannot add borrow invalid data. Try again");
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
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred while adding a borrow.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }

    public Borrow? FindBorrow(string patronName, string bookTitle)
    {
        return Borrows.Find(b => b.GetPatron().getName().Equals(patronName, StringComparison.OrdinalIgnoreCase) &&
        b.GetBook().Title.Equals(bookTitle, StringComparison.OrdinalIgnoreCase));
    }

    public void ActiveBorrowsFromPatron(Patron patron)
    {

        try
        {
            System.Console.WriteLine("LIST OF NOT RETURNED BORROWS");

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
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred while listing active borrows.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }
    
    public List<Borrow> GetBorrows() => Borrows;
}
