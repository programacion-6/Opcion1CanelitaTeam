using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Logs;
using LMS.DataAccess.Services.Reports.Abstracts;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.Borrowing;

namespace LMS.DataAccess.Services.Reports.Concretes;

public class BorrowPatronHistory : BaseReport
{
    private readonly ILogService _logService;

    public BorrowPatronHistory(BorrowManager borrowManager) 
        : base(borrowManager)
    { 
        _logService = new LogService();
    }
    
    public override void GenerateReport()
    {
        System.Console.WriteLine("This is a Patron Borrow Report");
    }

    public void PatronBorrowHistoryReport(string patronName)
    {
        try
        {
            GenerateReport();
            
            List<Borrow> borrowList = _borrowManager.GetAll();
            if (borrowList == null || borrowList.Count == 0)
            {
                System.Console.WriteLine("There are no borrowing records in the system.");
                return;
            }

            bool foundBorrowForPatron = false;

            foreach (Borrow borrow in borrowList)
            {
                if (borrow.GetPatron().getName() == patronName)
                {
                    borrow.BorrowDetails();
                    foundBorrowForPatron = true;
                }
            }

            if (!foundBorrowForPatron)
            {
                ErrorHandler.HandleError(new BorrowNotFoundException($"No borrow records found for {patronName}."));
            }
        }
        catch (BorrowNotFoundException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred. Please contact your administrator.");
            _logService.LogError(Severity.MEDIUM, $"{ex.Message}");
        }
    }
}
