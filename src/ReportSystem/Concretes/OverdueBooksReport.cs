using BorrowSystem;

namespace Opcion1CanelitaTeam.ReportSystem.Concretes;

public class OverdueBooksReport : BaseReport
{
    public OverdueBooksReport(BorrowManager borrowManager) 
        : base(borrowManager)
    { }

    public override void GenerateReport()
    {
        Console.WriteLine("This is an Overdue Book Borrow Report");
    }

    public void OverdueBooksListReport()
    {
        GenerateReport();
        foreach (Borrow borrow in _borrowManager.GetBorrows())
        {
            if (DateTime.Now > borrow.GetDueDate())
            {
                borrow.BorrowDetails();
            }
        }        
    }
}
