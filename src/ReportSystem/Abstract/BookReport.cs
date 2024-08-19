using BorrowSystem;

public abstract class BookReport: Reporting
{
    protected BorrowManager BorrowList;
    public BookReport( BorrowManager BorrowList)
    {
        this.BorrowList = BorrowList;
    }

    public void generateReport()
    {
        Console.WriteLine("This is a book borrow Report");
    }
}