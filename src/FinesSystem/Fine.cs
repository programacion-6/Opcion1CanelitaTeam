using BorrowSystem;
using userSystem.Concrete;

namespace FinesSystem;
public class Fine{

    bool Paid;
    Borrow Borrow;

    int Cost;

    public Fine(Borrow borrow){
        this.Borrow = borrow;
        CalculateFine();
    }

    public void CalculateFine()
    {
        DateTime returnDate = DateTime.Now;
        TimeSpan difference = returnDate - Borrow.GetDueDate();

        int weeksLate = (int)(difference.TotalDays / 7);

        this.Cost = difference.TotalDays > 0 ? 20 + weeksLate * 10 : 0;
    }

    public void FineDetails()
    {
        Console.WriteLine("========== Fine Details ==========");
        Console.WriteLine($"Patron Name:          {Borrow.GetPatron().getName()}");
        Console.WriteLine($"Book Title:           {Borrow.GetBook().getTitle()}");
        Console.WriteLine($"Borrow Date:          {Borrow.GetBorrowDate()}");
        Console.WriteLine($"Due Date:             {Borrow.GetDueDate()}");
        Console.WriteLine($"Return Date:          {DateTime.Now}");
        Console.WriteLine($"Fine Amount:          ${Cost}");
        Console.WriteLine($"Paid:                 {(Paid ? "Yes" : "No")}");
        Console.WriteLine("==================================");
    }

    public bool GetPaid() => Paid;
    public Borrow GetBorrow() => Borrow;
    public void SetPaid(bool paid) => this.Paid = paid;
}