using BorrowSystem;

namespace FinesSystem;

public class Fine
{
    bool Paid;
    Borrow Borrow;
    int Cost;

    public Fine(Borrow borrow)
    {
        Borrow = borrow;
        CalculateFine();
    }

    public void CalculateFine()
    {
        const int BASE_FINE = 20;
        const int WEEKLY_FINE = 10;
        DateTime returnDate = DateTime.Now;
        TimeSpan difference = returnDate - Borrow.GetDueDate();
        
        if (difference.TotalDays < 0)
        {
            throw new InvalidOperationException("Return date cannot be before the due date.");
        }
        
        int weeksLate = (int)(difference.TotalDays / 7);

        Cost = difference.TotalDays > 0 ? BASE_FINE + weeksLate * WEEKLY_FINE : 0;
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
