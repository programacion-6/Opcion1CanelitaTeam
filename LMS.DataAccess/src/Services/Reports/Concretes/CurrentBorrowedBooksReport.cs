using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Services.Reports.Abstracts;
using LMS.DataAccess.Systems.Concretes.Managers;

using Spectre.Console;

namespace LMS.DataAccess.Services.Reports.Concretes;

public class CurrentBorrowBooksReport : BaseReport
{
    private readonly ILogService _logService;

    public CurrentBorrowBooksReport(BorrowManager borrowManager) 
        : base(borrowManager)
    { 
            _logService = new LogService();
    }
    
    public override void GenerateReport()
    {
        System.Console.WriteLine("This is a Current Book Borrow Report");
    }

    public void BorrowedBooksReport()
    {
        try
        {
            GenerateReport();

            var activeBorrows = _borrowManager.GetBorrows().Where(borrow => !borrow.GetDelivered()).ToList();

            if (activeBorrows == null)
            {
                throw new InvalidOperationException("Failed to retrieve borrow records.");
            }

            int pageSize = 2;
            int totalPages = (int)Math.Ceiling((double)activeBorrows.Count / pageSize);
            int currentPage = 1;

            while (true)
            {
                var currentBorrowPage = activeBorrows.Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();

                var table = new Table();
                table.AddColumn("Borrower");
                table.AddColumn("Book Title");
                table.AddColumn("Borrow Date");
                table.AddColumn("Due Date");

                foreach (var borrow in currentBorrowPage)
                {
                    table.AddRow(
                        borrow.GetPatron().getName(),
                        borrow.GetBook().Title,
                        borrow.GetBorrowDate().ToString("yyyy-MM-dd"),
                        borrow.GetDueDate().ToString("yyyy-MM-dd"));
                }

                AnsiConsole.Clear();
                AnsiConsole.Write(table);

                AnsiConsole.MarkupLine($"[bold]Page {currentPage} of {totalPages}[/]");
                var choices = new List<string>();

                if (currentPage > 1)
                {
                    choices.Add("Previous");
                }

                if (currentPage < totalPages)
                {
                    choices.Add("Next");
                }

                choices.Add("Exit");

                var selectedOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Navigate:")
                        .AddChoices(choices)
                );

                switch (selectedOption)
                {
                    case "Previous":
                        currentPage--;
                        break;
                    case "Next":
                        currentPage++;
                        break;
                    case "Exit":
                        return;
                }
            }
        }
        catch (InvalidOperationException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An unexpected error occurred while generating the borrowed books report. Please contact your administrator.");
            _logService.LogError(Severity.MEDIUM, $"{ex.Message}");
        }
    }
}
