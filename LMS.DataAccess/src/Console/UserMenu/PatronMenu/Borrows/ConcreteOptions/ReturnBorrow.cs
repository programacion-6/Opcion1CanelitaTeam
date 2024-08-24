using BookSystem;
using BorrowSystem;
using FinesSystem;
using Spectre.Console;
using userSystem.Concrete;

public class ReturnBorrow : BorrowInput
{
    Patron Patron;
    BorrowManager Borrows;
    BookRepository Books;
    FineManager Fines;

    public ReturnBorrow(Patron patron, BorrowManager borrows, BookRepository books, FineManager fines)
    {
        this.Patron = patron;
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    public void BorrowOption()
    {
        AnsiConsole.Clear();
        Borrows.ActiveBorrowsFromPatron(Patron); 
        Console.WriteLine("Enter the title of the book to return: ");
        
        string? bookTitle = Console.ReadLine();

        if(bookTitle != null){

            Borrow borrow = (Borrow)PerformFind.Execute(new FindBorrow(Borrows, Patron.getName(), bookTitle));

            if(borrow != null){
                borrow.ReturnBook();
                ((Book)PerformFind.Execute(new FindBookByTitle(Books, bookTitle))).IncreaseStock();
                Console.WriteLine($"Succesfull returned {bookTitle}");
                if(DateTime.Now > borrow.GetDueDate()){
                    Fine currentFine = new Fine(borrow);
                    Fines.AddFine(currentFine);
                    Console.WriteLine($"A Fine was created because DueDate was {borrow.GetDueDate()} and was returned on {DateTime.Now}");
                    currentFine.FineDetails();
                }
            }else{
                Console.WriteLine($"User {Patron.getName()} dont have a borrow with this title");
            }       
        }
    }
}