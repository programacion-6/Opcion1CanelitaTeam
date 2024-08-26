using LMS.DataAccess.BookSystem.Entities;
using LMS.DataAccess.Console.Utils.ItemsList.Interfaces;

using Spectre.Console;

namespace LMS.DataAccess.Console.Utils.ItemsList.Concretes;

public class BookPagination : ListPagination
{
    private readonly List<Book> _books;

    public BookPagination(List<Book> books)
    {
        _books = books.Where(b => b.Stock > 0).ToList();
    }

    public void DisplayList()
    {
        if (_books.Count == 0)
        {
            AnsiConsole.MarkupLine("[yellow]No books available.[/]");
            return;
        }

        int pageSize = 3;
        int currentPage = 1;
        int totalPages = (_books.Count + pageSize - 1) / pageSize;

        while (true)
        {
            var currentPageBooks = _books
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            AnsiConsole.Clear();
            AnsiConsole.MarkupLine($"[bold]Page {currentPage}/{totalPages}[/]");

            var table = new Table();
            table.AddColumn("Title");
            table.AddColumn("Author");
            table.AddColumn("Genre");
            table.AddColumn("Publication Date");
            table.AddColumn("Stock");

            foreach (var book in currentPageBooks)
            {
                table.AddRow(
                    book.Title,
                    book.Author,
                    book.Genre,
                    book.PublicationDate.ToString("yyyy-MM-dd"),
                    book.Stock.ToString());
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
                    .Title("Navigate through the books")
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
