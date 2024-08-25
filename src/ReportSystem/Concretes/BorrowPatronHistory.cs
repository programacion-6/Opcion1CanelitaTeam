using BorrowSystem;
using Opcion1CanelitaTeam.ReportSystem.Abstracts;

namespace Opcion1CanelitaTeam.ReportSystem.Concretes;

public class BorrowPatronHistory : BaseReport
{
    public BorrowPatronHistory(BorrowManager borrowManager) 
        : base(borrowManager)
    { }
    
    public override void GenerateReport()
    {
        Console.WriteLine("This is a Patron Borrow Report");
    }

    public void PatronBorrowHistoryReport(string patronName)
    {
        GenerateReport();
        foreach (Borrow borrow in _borrowManager.GetBorrows())
        {
            if (borrow.GetPatron().getName() == patronName)
            {
                borrow.BorrowDetails();
            }
        }        
    }
}
