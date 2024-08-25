using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Report.Interfaces;
using LMS.DataAccess.ReportSystem.Concretes;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Report.Concretes;

public class BorrowPatronHistoryInput : ReportInput
{
    BorrowManager _borrows;

    public BorrowPatronHistoryInput(BorrowManager _borrows)
    {
        this._borrows = _borrows;
    }
    public void ReportOption()
    {
        var patronName = AnsiConsole.Ask<string>("Enter Patron Name:");
        var history = new BorrowPatronHistory(_borrows);
        history.PatronBorrowHistoryReport(patronName);
    }
}
