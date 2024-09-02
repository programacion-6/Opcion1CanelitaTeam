using LMS.DataAccess.Console.Utils.ItemsList.Interfaces;
using LMS.DataAccess.Systems.Entities.Borrowing;
using Spectre.Console;

public class BorrowPagination : ListPagination
{
    private readonly List<Borrow> _borrows;

    public BorrowPagination(List<Borrow> borrows)
    {
        _borrows = borrows;
    }

    public void DisplayList()
    {
        if (_borrows.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No active borrows found.[/]");
            return;
        }

        int pageSize = 5;
        int currentPage = 1;
        int totalPages = (_borrows.Count + pageSize - 1) / pageSize;

        while (true)
        {
            var currentPageBorrows = _borrows
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold]Page {currentPage}/{totalPages}[/]");

            var table = new Table();
            table.AddColumn("Patron");
            table.AddColumn("Book");
            table.AddColumn("Borrow Date");
            table.AddColumn("Due Date");
            table.AddColumn("Returned");

            foreach (var borrow in currentPageBorrows)
            {
                table.AddRow(
                    borrow.GetPatron().getName(),
                    borrow.GetBook().Title,
                    borrow.GetBorrowDate().ToString("yyyy-MM-dd"),
                    borrow.GetDueDate().ToString("yyyy-MM-dd"),
                    borrow.GetDelivered() ? "[green]Yes[/]" : "[red]No[/]");
            }

            AnsiConsole.Write(table);

            var options = new List<string>();

            if (currentPage > 1)
                options.Add("Previous Page");
            if (currentPage < totalPages)
                options.Add("Next Page");

            options.Add("Exit");

            var selectedOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Navigate through active borrows")
                    .AddChoices(options)
            );

            if (selectedOption == "Previous Page")
                currentPage--;
            else if (selectedOption == "Next Page")
                currentPage++;
            else if (selectedOption == "Exit")
                break;
        }
    }
}
