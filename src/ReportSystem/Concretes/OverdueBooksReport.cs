using BorrowSystem;

namespace ReportSystem.Concrete;
public class OverdueBooksReport : BookReport
{
    public OverdueBooksReport(BorrowManager BorrowList) : base(BorrowList){}

    public void OverdueBooksListReport()
    {
        generateReport();
        foreach(Borrow borrow in BorrowList.GetBorrows()){
            if(DateTime.Now > borrow.GetDueDate()){
                borrow.BorrowDetails();
            }
        }        
    }
}