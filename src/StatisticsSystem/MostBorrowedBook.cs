using System.Linq;
using BorrowSystem;
using Spectre.Console;

public class MostBorrowedBook : StatisticReport
{
    public MostBorrowedBook(BorrowManager borrows) : base(borrows)
    {
    }

    public override void Report()
    {
        var borrowList = Borrows.GetBorrows();

        var topBooks = borrowList
            .GroupBy(b => b.GetBook().Title)
            .OrderByDescending(g => g.Count())
            .Take(3)
            .Select(g => new { BookTitle = g.Key, BorrowCount = g.Count() })
            .ToList();

        if (topBooks.Any())
        {
            var chart = new BarChart()
                .Width(60)
                .Label("[bold underline]Top 3 Most Borrowed Books[/]")
                .CenterLabel();

            foreach (var book in topBooks)
            {
                chart.AddItem(book.BookTitle, book.BorrowCount, Color.Blue);
            }

            AnsiConsole.Write(chart);
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No books have been borrowed yet.[/]");
        }
    }
}
