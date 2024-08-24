using System.Linq;
using BorrowSystem;
using Spectre.Console;

public class MostActivePatron : StatisticReport
{
    public MostActivePatron(BorrowManager borrows) : base(borrows)
    {
    }

    public override void Report()
    {
        var borrowList = Borrows.GetBorrows();

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
}
