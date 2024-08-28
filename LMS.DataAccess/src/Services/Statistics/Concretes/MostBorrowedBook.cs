using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.Core.Exceptions;
using LMS.DataAccess.Core.Handlers;

using Spectre.Console;

namespace LMS.DataAccess.StatisticSystem;

public class MostBorrowedBook : StatisticReport
{
    private readonly ILogService _logService;

    public MostBorrowedBook(BorrowManager borrows)
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
