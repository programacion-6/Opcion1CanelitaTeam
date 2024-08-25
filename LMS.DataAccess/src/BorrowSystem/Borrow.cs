using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.UserSystem.Concretes;

using Spectre.Console;

namespace LMS.DataAccess.BorrowSystem;

public class Borrow : Borrowing
{
    Book Book;
    Patron Patron;
    DateTime BorrowDate;
    DateTime DueDate;
    bool Delivered;

    public Borrow(Patron patron, Book book, DateTime borrowDate, DateTime DueDate)
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
        var deliveredText = Delivered ? "[green]Yes[/]" : "[red]No[/]";

        AnsiConsole.MarkupLine("[bold]========== Borrow Details ==========[/]");
        AnsiConsole.MarkupLine($"[bold]Patron Name:[/]      {Patron.getName()}");
        AnsiConsole.MarkupLine($"[bold]Book Title:[/]       {Book.Title}");
        AnsiConsole.MarkupLine($"[bold]Borrow Date:[/]      {BorrowDate:yyyy-MM-dd}");
        AnsiConsole.MarkupLine($"[bold]Due Date:[/]         {DueDate:yyyy-MM-dd}");
        AnsiConsole.MarkupLine($"[bold]Delivered:[/]        {deliveredText}");
        AnsiConsole.MarkupLine("[bold]====================================[/]");
    }

}
