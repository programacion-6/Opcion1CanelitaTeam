using BorrowSystem;
using Core.Exceptions;
using Core.Handlers;

namespace FinesSystem;

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
                throw new InvalidDateRangeException("Return date cannot be before the due date.");
            }

            int weeksLate = (int)(difference.TotalDays / NUMBER_OF_DAYS);

            Cost = difference.TotalDays > 0 ? BASE_FINE + weeksLate * WEEKLY_FINE : 0;
        }
        catch (InvalidDateRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while calculating the fine.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }

    public void FineDetails()
    {
        Console.WriteLine("========== Fine Details ==========");
        Console.WriteLine($"Patron Name:          {Borrow.GetPatron().getName()}");
        Console.WriteLine($"Book Title:           {Borrow.GetBook().Title}");
        Console.WriteLine($"Borrow Date:          {Borrow.GetBorrowDate()}");
        Console.WriteLine($"Due Date:             {Borrow.GetDueDate()}");
        Console.WriteLine($"Return Date:          {DateTime.Now}");
        Console.WriteLine($"Fine Amount:          ${Cost}");
        Console.WriteLine($"Paid:                 {(Paid ? "Yes" : "No")}");
        Console.WriteLine("==================================");
    }

    public bool GetPaid() => Paid;

    public int GetCost() => Cost;

    public Borrow GetBorrow() => Borrow;
    
    public void SetPaid(bool paid) => Paid = paid;
}
