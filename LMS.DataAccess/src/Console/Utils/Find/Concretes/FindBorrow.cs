using LMS.DataAccess.Console.Utils.Find.Interfaces;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.Borrowing;

namespace LMS.DataAccess.Console.Utils.Find.Concretes;

public class FindBorrow : FindProcess
{
    BorrowManager Borrows;
    string PatronName;
    string BookTitle;
    public FindBorrow(BorrowManager Borrows, string patronName, string BookTitle)
    {
        this.Borrows = Borrows;
        this.PatronName = patronName;
        this.BookTitle = BookTitle;
    }

    public object FindItem()
    {
        foreach (Borrow borrow in Borrows.GetBorrows())
        {
            string currentPatron = borrow.GetPatron().getName();
            string currentBook = borrow.GetBook().Title;
            if (currentPatron == PatronName && currentBook == BookTitle)
            {
                return borrow;
            }
        }
        throw new InvalidOperationException("The requested item was not found."); ;
    }
}
