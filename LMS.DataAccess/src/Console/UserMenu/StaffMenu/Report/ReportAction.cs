using LMS.DataAccess.Console.UserMenu.StaffMenu.Report.Interfaces;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Report;

public class ReportAction
{

    ReportInput? _report;
    public void SetReportInput(ReportInput report)
    {
        this._report = report;
    }

    public void Execute()
    {
        if (_report != null)
        {
            _report.ReportOption();
        }
    }
}
