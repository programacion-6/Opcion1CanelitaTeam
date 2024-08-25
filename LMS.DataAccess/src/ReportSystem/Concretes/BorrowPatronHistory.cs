<<<<<<< HEAD
using BorrowSystem;
using Core.Exceptions;
using Core.Handlers;
using Opcion1CanelitaTeam.ReportSystem.Abstracts;
=======
using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.ReportSystem.Abstracts;
>>>>>>> 258ac0d (refactor: add namespaces and rename directories without errors)

namespace LMS.DataAccess.ReportSystem.Concretes;

public class BorrowPatronHistory : PatronReport
{
    private readonly ILogService _logService;

    public BorrowPatronHistory(BorrowManager borrowManager) 
        : base(borrowManager)
    { 
        _logService = new LogService();
    }
    
    public override void GenerateReport()
    {
        Console.WriteLine("This is a Patron Borrow Report");
    }

    public void PatronBorrowHistoryReport(string patronName)
    {
        try
        {
            GenerateReport();
            
            List<Borrow> borrowList = _borrowManager.GetBorrows();
            if (borrowList == null || borrowList.Count == 0)
            {
                Console.WriteLine("There are no borrowing records in the system.");
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
                throw new BorrowNotFoundException($"No borrow records found for {patronName}.");
            }
        }
        catch (BorrowNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An unexpected error occurred. Please contact your administrator.");
            _logService.LogError(Severity.MEDIUM, $"{ex.Message}");
        }
    }
}
