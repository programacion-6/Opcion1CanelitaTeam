using BorrowSystem;

public class ReportAction {

    ReportInput? _report;
    public void SetReportInput(ReportInput report)
    {
        this._report = report;
    }

    public void Execute()
    {
        if(_report != null)
        {
            _report.ReportOption();
        }
    }
}