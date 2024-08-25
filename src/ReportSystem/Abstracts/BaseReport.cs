using BorrowSystem;
using Opcion1CanelitaTeam.ReportSystem.Interfaces;

namespace Opcion1CanelitaTeam.ReportSystem.Abstracts;

public abstract class BaseReport : IReport
{
    protected BorrowManager _borrowManager;
    
    public BaseReport(BorrowManager borrowManager)
    {
        _borrowManager = borrowManager;
    }

    public abstract void GenerateReport();
}
