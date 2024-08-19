using BookSystem;
using userSystem.Concrete;

namespace BorrowSystem;
public class BorrowManager{
    List<Borrow> Borrows;
    public BorrowManager(List<Borrow> borrows){
        this.Borrows = borrows;
    }

    public void AddBorrow(Patron patron, Book book, DateTime borrowDate, DateTime dueDate)
    {
        Borrow borrow = new Borrow(patron, book, borrowDate, dueDate);
        if(book.getStock() > 0){
            Borrows.Add(borrow);
            Console.WriteLine($"Successfull Borrow of {book.getTitle()}"); 
        }else{
            Console.WriteLine($"{book.getTitle} Has no available copies the stock is {book.getStock}");
        }
           
    }

    public void RemoveBorrow(string patronName, string bookTitle)
    {
       Borrow? borrow = FindBorrow(patronName, bookTitle);
        if (borrow != null)
        {
            Borrows.Remove(borrow);
        } 
    }

    public Borrow? FindBorrow(string patronName, string bookTitle )
    {
        foreach (Borrow borrow in Borrows)
            {
                string currentPatron = borrow.GetPatron().getName();
                string currentBook = borrow.GetBook().getTitle(); 
                if (currentPatron == patronName && currentBook == bookTitle)
                {
                    return borrow;
                }
            }
        return null;        
    }

    public void ActiveBorrowsFromPatron(Patron patron){
        Console.WriteLine("lIST OF NOT RETURNED BORROWS");
        foreach (Borrow borrow in Borrows)
        {
            if(borrow.GetPatron().getName().Equals(patron.getName()) && borrow.GetDelivered() == false)
            {
                borrow.BorrowDetails();
            }
        }
    }
    public List<Borrow> GetBorrows() => Borrows;
}