using BookSystem;
using BorrowSystem;
using FinesSystem;
using LibraryConsole.Utils;
using userSystem.Concrete;

public class PatronsBorrowMenu
{
    BorrowManager Borrows;
    Patron Patron;
    BookRepository Books;
    FineManager Fines;

    public PatronsBorrowMenu(BorrowManager Borrows, Patron patron, BookRepository books, FineManager fines)
    {
        this.Borrows = Borrows;
        this.Patron = patron;
        this.Books = books;
        this.Fines = fines;
    }
    public void PatronBooksMenu(){
        List<string> options = new List<string> { "Borrow book", "Return book", "Exit" };

        while (true)
        {
            MenuGenerator.genericMenu("Patron Books Menu", options);
            Console.Write("Please select an option: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= options.Count)
            {
                switch (selectedIndex)
                {
                    case 1:
                        BorrowBookOption();
                        break;
                    case 2:
                        ReturnBookOption();
                        break;
                    case 3:
                        Console.WriteLine("Exiting to Patron Menu.");
                        return;
                    default:
                        Console.WriteLine("Invalid selection. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid selection. Please try again.");
            }
        }


    }

    private void BorrowBookOption(){
        Console.WriteLine("Enter the title of the book to borrow: ");
        string bookTitle = Console.ReadLine()
        ;
        Book book = Books.FoundBookByTitle(bookTitle);
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

    private void ReturnBookOption(){
        Borrows.ActiveBorrowsFromPatron(Patron); 
        Console.WriteLine("Enter the title of the book to return: ");
        
        string bookTitle = Console.ReadLine();
        Borrow borrow = Borrows.FindBorrow(Patron.getName(), bookTitle);
        if(borrow != null){
            borrow.ReturnBook();
            Books.FoundBookByTitle(bookTitle).IncreaseStock();
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