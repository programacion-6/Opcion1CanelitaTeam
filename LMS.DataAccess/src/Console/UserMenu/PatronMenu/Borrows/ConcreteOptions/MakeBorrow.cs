using BookSystem;
using BorrowSystem;
using Spectre.Console;
using userSystem.Concrete;

public class MakeBorrow : BorrowInput
{
    BookRepository Books;
    Patron Patron;
    BorrowManager Borrows;

    public MakeBorrow (BookRepository Books, Patron Patron, BorrowManager Borrows)
    {
        this.Books = Books;
        this.Patron = Patron;
        this.Borrows = Borrows;
    }
    public void BorrowOption()
    {
        AnsiConsole.Clear();
        Console.WriteLine("Enter the title of the book to borrow: ");
        string? bookTitle = Console.ReadLine();

        if(bookTitle != null){
            Book book = (Book)PerformFind.Execute(new FindBookByTitle(Books, bookTitle));

            if(book != null)
            {
                DateTime BorrowDate = DateTime.Now;
                DateTime DueDate = BorrowDate.AddMonths(1);
                book.DecreaseStock();
                
                Borrows.AddBorrow(Patron, book, BorrowDate, DueDate);
            }else{
                Console.WriteLine($"There is no book with {bookTitle} Title");
            }
        }
    }
}