using BorrowSystem;
using Core.Handlers;
using Opcion1CanelitaTeam.ReportSystem.Abstracts;

namespace Opcion1CanelitaTeam.ReportSystem.Concretes;

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
        Console.WriteLine("This is an Overdue Book Borrow Report");
    }

    public void OverdueBooksListReport()
    {
        try
        {
            GenerateReport();

            List<Borrow> borrowList = _borrowManager.GetBorrows();
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
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred while generating the borrowed books report. Please contact your administrator.");
            _logService.LogError(Severity.HIGH, $"{ex.Message}");
        }
    }
}
