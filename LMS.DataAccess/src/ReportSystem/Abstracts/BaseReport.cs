using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.ReportSystem.Interfaces;

namespace LMS.DataAccess.ReportSystem.Abstracts;

public abstract class BaseReport : IReport
{
    protected BorrowManager _borrowManager;
    
    public BaseReport(BorrowManager borrowManager)
    {
        _borrowManager = borrowManager;
    }

    public abstract void GenerateReport();
}
