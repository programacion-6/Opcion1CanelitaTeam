using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.Core.Exceptions;
using LMS.DataAccess.Core.Handlers;

using Spectre.Console;

namespace LMS.DataAccess.StatisticSystem;

public class MostActivePatron : StatisticReport
{
    private readonly ILogService _logService;
    
    public MostActivePatron(BorrowManager borrows) 
        : base(borrows)
    {
        _logService = new LogService();
    }

    public override void Report()
    {
        try
        {
            var borrowList = Borrows.GetBorrows();

            if (borrowList == null)
            {
                throw new BorrowNotFoundException("Failed to retrieve borrow records. The list doesn't exist.");
            }

            var topPatrons = borrowList
                .GroupBy(b => b.GetPatron().getName())
                .OrderByDescending(g => g.Count())
                .Take(3)
                .Select(g => new { PatronName = g.Key, BorrowCount = g.Count() })
                .ToList();
            
            if (topPatrons.Any())
            {
                var chart = new BarChart()
                    .Width(60)
                    .Label("[bold underline]Top 3 Most Active Patrons[/]")
                    .CenterLabel();

                foreach (var patron in topPatrons)
                {
                    chart.AddItem(patron.PatronName, patron.BorrowCount, Color.Green);
                }
                
                AnsiConsole.Write(chart);
            }
            else
            {
                AnsiConsole.MarkupLine("[red]No patrons have borrowed books yet.[/]");
            }
        } 
        catch (BorrowNotFoundException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred while generating the report. Please contact your administrator.");
            _logService.LogError(Severity.MEDIUM, $"{ex.Message}");
        }
    }
}
