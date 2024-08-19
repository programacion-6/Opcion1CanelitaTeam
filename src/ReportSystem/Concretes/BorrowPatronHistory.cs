using BorrowSystem;

namespace ReportSystem.Concrete;
public class BorrowPatronHistory : PatronReport
{
    public BorrowPatronHistory(BorrowManager BorrowList) : base(BorrowList){}

    public void PatronBorrowHistoryReport(string PatronName)
    {
        generateReport();
        foreach(Borrow borrow in Borrows.GetBorrows()){
            if(borrow.GetPatron().getName() == PatronName){
                borrow.BorrowDetails();
            }
        }        
    }
}