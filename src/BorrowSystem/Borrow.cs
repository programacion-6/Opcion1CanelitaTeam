namespace BorrowSystem;
using BookSystem;
using userSystem.Concrete;

public class Borrow : Borrowing{
    Book Book;
    Patron Patron;
    DateTime BorrowDate;
    DateTime DueDate;
    bool Delivered;

    public Borrow (Patron patron, Book book, DateTime borrowDate, DateTime DueDate)
    {
        this.Patron = patron;
        this.Book = book;
        this.BorrowDate = borrowDate;
        this.DueDate = DueDate;
        Delivered = false;
    }

    public void ReturnBook()
    {
        this.Delivered = true;
    }

    public Book GetBook() => this.Book;
    public Patron GetPatron() => this.Patron;
    public DateTime GetBorrowDate() => this.BorrowDate;
    public DateTime GetDueDate() => this.DueDate;
    public bool GetDelivered() => this.Delivered;

    public void SetBook(Book book) => this.Book = book;
    public void SetPatron(Patron patron) => this.Patron = patron;
    public void SetBorrowDate(DateTime borrowDate) => this.BorrowDate = borrowDate;
    public void SetDueDate(DateTime dueDate) => this.DueDate = dueDate;
    public void SetDelivered(bool delivered) => this.Delivered = delivered;

    public void BorrowDetails() 
    {
        Console.WriteLine("========== Borrow Details ==========");
        Console.WriteLine($"Patron Name:          {Patron.getName()}");
        Console.WriteLine($"Book Title:           {Book.Title}");
        Console.WriteLine($"Borrow Date:          {BorrowDate}");
        Console.WriteLine($"Due Date:             {DueDate}");
        Console.WriteLine($"Delivered:               {Delivered}");
        Console.WriteLine("====================================");
    }

}