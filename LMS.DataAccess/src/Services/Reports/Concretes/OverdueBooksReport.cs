using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Logs;
using LMS.DataAccess.Services.Reports.Abstracts;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.Borrowing;

namespace LMS.DataAccess.Services.Reports.Concretes;

public class OverdueBooksReport : BaseReport
{
    private readonly ILogService _logService;

    public OverdueBooksReport(BorrowManager borrowManager) 
        : base(borrowManager)
    { 
        _logService = new LogService();
    }

    public override void GenerateReport()
    {
        System.Console.WriteLine("This is an Overdue Book Borrow Report");
    }

    public void OverdueBooksListReport()
    {
        try
        {
            GenerateReport();

            List<Borrow> borrowList = _borrowManager.GetAll();
            if (borrowList == null)
            {
                throw new InvalidOperationException("Failed to retrieve borrow records. The list is null.");
            }

            foreach (Borrow borrow in borrowList)
            {
                if (DateTime.Now > borrow.GetDueDate())
                {
                    borrow.BorrowDetails();
                }
            }
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred while generating the borrowed books report. Please contact your administrator.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }
}
