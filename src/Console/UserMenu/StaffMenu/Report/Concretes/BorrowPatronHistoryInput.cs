using BorrowSystem;
using Opcion1CanelitaTeam.ReportSystem.Concretes;
using Spectre.Console;

public class BorrowPatronHistoryInput : ReportInput
{
    BorrowManager _borrows;

    public BorrowPatronHistoryInput (BorrowManager _borrows) {
        this._borrows = _borrows;
    }
    public void ReportOption()
    {
        var patronName = AnsiConsole.Ask<string>("Enter Patron Name:");
        var history = new BorrowPatronHistory(_borrows);
        history.PatronBorrowHistoryReport(patronName);
    }
}