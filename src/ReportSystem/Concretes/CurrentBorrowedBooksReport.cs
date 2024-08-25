using BorrowSystem;
using Opcion1CanelitaTeam.ReportSystem.Abstracts;
using Spectre.Console;

namespace ReportSystem.Concrete
{
    public class CurrentBorrowBooksReport : BaseReport
    {
        public CurrentBorrowBooksReport(BorrowManager borrowManager) 
            : base(borrowManager)
        { }
    
        public override void GenerateReport()
        {
            Console.WriteLine("This is a Current Book Borrow Report");
        }

        public void BorrowedBooksReport()
        {
            GenerateReport();

            var activeBorrows = _borrowManager.GetBorrows().Where(borrow => !borrow.GetDelivered()).ToList();

           
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
    }
}
