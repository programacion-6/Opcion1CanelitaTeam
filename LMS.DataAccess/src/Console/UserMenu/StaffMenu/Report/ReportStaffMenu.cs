using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.Console.UserMenu.StaffMenu.Report.Concretes;
using LMS.DataAccess.Console.Utils.ItemsList;
using LMS.DataAccess.Console.Utils.ItemsList.Concretes;
using LMS.DataAccess.FineSystem;
using LMS.DataAccess.ReportSystem.Concretes;
using LMS.DataAccess.StatisticSystem;
using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Report;

public class ReportStaffMenu
{
    private readonly BorrowManager _borrows;
    private readonly FineManager _fines;

    public ReportStaffMenu(BorrowManager borrows, FineManager fines)
    {
        _borrows = borrows;
        _fines = fines;
    }

    public void ReportMenu()
    {
        var options = new List<string> 
        { 
            "Borrow Patron History", 
            "Current Borrowed Books", 
            "Overdue Books Report", 
            "Statistics", 
            "Fines List", 
            "Exit" 
        };


        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Markup("[bold]Report Staff Menu[/]\n"));
            var selection = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Please select an option:")
                    .AddChoices(options)
            );

            ReportAction report = new ReportAction();
            ListAction page = new ListAction(); 

            switch (selection)
            {
                case "Borrow Patron History":
                    report.SetReportInput(new BorrowPatronHistoryInput(_borrows));
                    report.Execute();
                    AnsiConsole.MarkupLine("[yellow]Press any key to return to the menu...[/]");
                    Console.ReadKey(); 
                    break;
                case "Current Borrowed Books":
                    var borrowedBooks = new CurrentBorrowBooksReport(_borrows);
                    borrowedBooks.BorrowedBooksReport();
                    break;
                case "Overdue Books Report":
                    var overdueBooks = new OverdueBooksReport(_borrows);
                    overdueBooks.OverdueBooksListReport();
                    AnsiConsole.MarkupLine("[yellow]Press any key to return to the menu...[/]");
                    Console.ReadKey(); 
                    break;
                case "Statistics":
                    var statistics = new Statistic(new MostActivePatron(_borrows));
                    statistics.makeStatistic();
                    statistics = new Statistic(new MostBorrowedBook(_borrows));
                    statistics.makeStatistic();
                    AnsiConsole.MarkupLine("[yellow]Press any key to return to the menu...[/]");
                    Console.ReadKey(); 
                    break;
                case "Fines List":
                    page.setPagination(new FinesPagination(_fines.GetFines()));
                    page.Execute();
                    break;
                case "Exit":
                    AnsiConsole.MarkupLine("[green]Exiting to main menu.[/]");
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid selection. Please try again.[/]");
                    break;
            }
        }
    }
}
