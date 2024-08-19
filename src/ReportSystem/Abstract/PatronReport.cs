using BorrowSystem;

public abstract class PatronReport : Reporting
{
    protected BorrowManager Borrows;
    public PatronReport(BorrowManager Borrows)
    {
        this.Borrows = Borrows;
    }

    public void generateReport()
    {
        Console.WriteLine("This is a Patron borow Report");
    }
}