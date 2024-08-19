using BorrowSystem;

namespace ReportSystem.Concrete;
public class CurrrentBorrowBooksReport : BookReport
{
    public CurrrentBorrowBooksReport(BorrowManager BorrowList) : base(BorrowList){}

    public void BorrowedBooksReport()
    {
        generateReport();
        foreach(Borrow borrow in BorrowList.GetBorrows()){
            if(borrow.GetDelivered() == false){
                borrow.BorrowDetails();
            }
        }        
    }
}