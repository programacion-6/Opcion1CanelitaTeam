using LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Concretes;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;

using Spectre.Console;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows;

public class PatronsBorrowMenu
{
    private readonly BorrowManager _borrows;
    private readonly Patron _patron;
    private readonly BookManager _books;
    private readonly FineManager _fines;

    public PatronsBorrowMenu(BorrowManager borrows, Patron patron, BookManager books, FineManager fines)
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
            AnsiConsole.Clear();
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
                    Pause();
                    break;

                case "Return book":
                    borrowAction = new BorrowAction();          
                    AnsiConsole.Clear();
                    borrowAction.SetBorrow(new ReturnBorrow(_patron, _borrows, _books, _fines));
                    borrowAction.Execute();
                    Pause();
                    break;

                case "Exit":
                    System.Console.WriteLine("Exiting to Patron Menu.");
                    return;

                default:
                    AnsiConsole.MarkupLine("[red]Invalid selection. Please try again.[/]");
                    break;
            }
        }
    }
    private void Pause()
    {
        AnsiConsole.MarkupLine("[gray]Press any key to continue...[/]");
        System.Console.ReadKey(true);
        AnsiConsole.Clear();
    }
}
