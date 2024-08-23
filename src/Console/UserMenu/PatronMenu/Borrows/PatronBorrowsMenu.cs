using BookSystem;
using BorrowSystem;
using FinesSystem;
using Spectre.Console;
using userSystem.Concrete;

public class PatronsBorrowMenu
{
    private readonly BorrowManager _borrows;
    private readonly Patron _patron;
    private readonly BookRepository _books;
    private readonly FineManager _fines;

    public PatronsBorrowMenu(BorrowManager borrows, Patron patron, BookRepository books, FineManager fines)
    {
        _borrows = borrows;
        _patron = patron;
        _books = books;
        _fines = fines;
    }

    public void PatronBooksMenu()
    {
        while (true)
        {
            var options = new[] { "Borrow book", "Return book", "Exit" };

            var selectedOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Patron Books Menu")
                    .AddChoices(options)
            );

            switch (selectedOption)
            {
                case "Borrow book":
                    var borrowAction = new BorrowAction();
                    borrowAction.SetBorrow(new MakeBorrow(_books, _patron, _borrows));
                    borrowAction.Execute();
                    break;

                case "Return book":
                    borrowAction = new BorrowAction();
                    borrowAction.SetBorrow(new ReturnBorrow(_patron, _borrows, _books, _fines));
                    borrowAction.Execute();
                    break;

                case "Exit":
                    Console.WriteLine("Exiting to Patron Menu.");
                    return;

                default:
                    AnsiConsole.MarkupLine("[red]Invalid selection. Please try again.[/]");
                    break;
            }
        }
    }
}