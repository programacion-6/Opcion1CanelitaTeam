using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Services.Validators;
using LMS.DataAccess.Core.Logs;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Entities.Borrowing;
using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Systems.Interfaces;

using Spectre.Console;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class BorrowManager : IBaseManager<Borrow>
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

    public bool Add(Borrow borrow)
    {

        if (_borrowValidator.ValidateBorrow(borrow))
        {
            Borrows.Add(borrow);
            System.Console.WriteLine($"Successful Borrow of {borrow.GetBook().Title} by {borrow.GetPatron().getName()}");
            return true;
        }
        else
        {
            System.Console.WriteLine($"Cannot add borrow invalid data. Try again");
            return false;
        }
    }

    public bool Remove(Borrow borrow)
    {
        try
        {
            if (borrow == null)
            {
                ErrorHandler.HandleError(new BorrowNotFoundException($"No borrow record found."));
                return false;
            }

            Borrows.Remove(borrow);
            return true;
        }
        catch (BorrowNotFoundException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred while adding a borrow.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
            return false;
        }
    }

    public bool Update(Borrow borrow)
    {
        var title = AnsiConsole.Ask<string>("[gray] Enter the title of the book:");
        var name = AnsiConsole.Ask<string>("[gray] Enter the name of the patron:");
        var borrowToUpdate = FindBorrow(name, title);
        if (borrowToUpdate != null)
        {
            borrowToUpdate.SetPatron(borrow.GetPatron());
            borrowToUpdate.SetBook(borrow.GetBook());
            borrowToUpdate.SetDueDate(borrow.GetDueDate());
            borrowToUpdate.SetBorrowDate(borrow.GetBorrowDate());
            borrowToUpdate.SetDelivered(borrow.GetDelivered());
            return true;
        }
        else
        {
            AnsiConsole.WriteLine("[gray] Borrow does not exist. [/]");
            return false;
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
            var activeBorrows = Borrows.Where(borrow => 
                borrow.GetPatron().getName().Equals(patron.getName()) && 
                !borrow.GetDelivered()).ToList();

            if (activeBorrows.Any())
            {
                var borrowPagination = new BorrowPagination(activeBorrows);
                borrowPagination.DisplayList();
            }
            else
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


    public List<Borrow> GetAll() => Borrows;
}
