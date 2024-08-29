using LMS.DataAccess.Console.Utils.ItemsList.Interfaces;
using LMS.DataAccess.Systems.Entities;

using Spectre.Console;

namespace LMS.DataAccess.Console.Utils.ItemsList.Concretes;

public class FinesPagination : ListPagination
{
    private readonly List<Fine> _fines;

    public FinesPagination(List<Fine> fines)
    {
        _fines = fines;
    }

    public void DisplayList()
    {
        if (_fines == null || !_fines.Any())
        {
            AnsiConsole.MarkupLine("[red]No fines available to display.[/]");
            return;
        }

        int pageSize = 5;
        int currentPage = 1;
        int totalPages = (_fines.Count + pageSize - 1) / pageSize;

        while (true)
        {
            var currentPageFines = _fines
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold]Page {currentPage}/{totalPages}[/]");

            if (!currentPageFines.Any())
            {
                AnsiConsole.MarkupLine("[red]No fines available on this page.[/]");
            }
            else
            {
                foreach (var fine in currentPageFines)
                {
                    AnsiConsole.MarkupLine("[bold]========== Fine Details ==========[/]");
                    AnsiConsole.MarkupLine($"[bold]Patron Name:[/]          {fine.GetBorrow().GetPatron().getName()}");
                    AnsiConsole.MarkupLine($"[bold]Book Title:[/]           {fine.GetBorrow().GetBook().Title}");
                    AnsiConsole.MarkupLine($"[bold]Borrow Date:[/]          {fine.GetBorrow().GetBorrowDate()}");
                    AnsiConsole.MarkupLine($"[bold]Due Date:[/]             {fine.GetBorrow().GetDueDate()}");
                    AnsiConsole.MarkupLine($"[bold]Return Date:[/]          {DateTime.Now}");
                    AnsiConsole.MarkupLine($"[bold]Fine Amount:[/]          ${fine.GetCost()}");
                    AnsiConsole.MarkupLine($"[bold]Paid:[/]                 {(fine.GetPaid() ? "[green]Yes[/]" : "[red]No[/]")}");
                    AnsiConsole.MarkupLine("[bold]==================================[/]");
                }
            }

            if (totalPages > 1)
            {
                var options = new List<string>();

                if (currentPage > 1)
                    options.Add("Previous Page");
                if (currentPage < totalPages)
                    options.Add("Next Page");

                options.Add("Exit");

                var selectedOption = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Navigate through the fines")
                        .AddChoices(options)
                );

                if (selectedOption == "Previous Page")
                    currentPage--;
                else if (selectedOption == "Next Page")
                    currentPage++;
                else if (selectedOption == "Exit")
                    break;
            }
            else
            {
                AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Only one page available")
                    .AddChoices("Exit"));
                break;
            }
        }
    }
}
