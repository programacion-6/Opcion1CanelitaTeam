using LMS.DataAccess.Services.Reports.Interfaces;
using LMS.DataAccess.Systems.Concretes.Managers;

namespace LMS.DataAccess.Services.Reports.Abstracts;

public abstract class BaseReport : IReport
{
    protected BorrowManager _borrowManager;
    
    public BaseReport(BorrowManager borrowManager)
    {
        _borrowManager = borrowManager;
    }

    public abstract void GenerateReport();
}
