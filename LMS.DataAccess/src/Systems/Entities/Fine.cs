using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Logs;
using LMS.DataAccess.Systems.Entities.Borrowing;

namespace LMS.DataAccess.Systems.Entities;

public class Fine
{
    bool Paid;
    Borrow Borrow;
    int Cost;
    private readonly ILogService _logService;

    public Fine(Borrow borrow)
    {
        Borrow = borrow;
        CalculateFine();
        _logService = new LogService();
    }

    public void CalculateFine()
    {
        try
        {
            const int BASE_FINE = 20;
            const int WEEKLY_FINE = 10;
            const int NUMBER_OF_DAYS = 7;
            
            DateTime returnDate = DateTime.Now;
            TimeSpan difference = returnDate - Borrow.GetDueDate();

            if (difference.TotalDays < 0)
            {
                ErrorHandler.HandleError(new InvalidDateRangeException("Return date cannot be before the due date."));
            }

            int weeksLate = (int)(difference.TotalDays / NUMBER_OF_DAYS);

            Cost = difference.TotalDays > 0 ? BASE_FINE + weeksLate * WEEKLY_FINE : 0;
        }
        catch (InvalidDateRangeException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An error occurred while calculating the fine.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }

    public void FineDetails()
    {
        System.Console.WriteLine("========== Fine Details ==========");
        System.Console.WriteLine($"Patron Name:          {Borrow.GetPatron().getName()}");
        System.Console.WriteLine($"Book Title:           {Borrow.GetBook().Title}");
        System.Console.WriteLine($"Borrow Date:          {Borrow.GetBorrowDate()}");
        System.Console.WriteLine($"Due Date:             {Borrow.GetDueDate()}");
        System.Console.WriteLine($"Return Date:          {DateTime.Now}");
        System.Console.WriteLine($"Fine Amount:          ${Cost}");
        System.Console.WriteLine($"Paid:                 {(Paid ? "Yes" : "No")}");
        System.Console.WriteLine("==================================");
    }

    public bool GetPaid() => Paid;

    public int GetCost() => Cost;

    public Borrow GetBorrow() => Borrow;
    
    public void SetPaid(bool paid) => Paid = paid;
}
