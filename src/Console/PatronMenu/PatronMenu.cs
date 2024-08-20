using BookSystem;
using BorrowSystem;
using LibraryConsole.Utils;
using userSystem.Concrete;
using FinesSystem;

namespace LibraryConsole.PatronMenuOtions;
public class PatronMenu{

    Patron Patron;
    BorrowManager Borrows;
    BookRepository Books;
    FineManager Fines;

    public PatronMenu(Patron patron, BorrowManager borrows, BookRepository books, FineManager fines){
        this.Patron = patron;
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    public void ShowPatronMenu()
    {
        List<string> options = new List<string> { "User details", "Borrow Options", "Search Tool", "BooksList", "Exit" };

        while (true)
            {
                MenuGenerator.genericMenu($"Welcome {Patron.getName()}", options);
                Console.Write("Please select an option: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int selectedIndex) && selectedIndex > 0 && selectedIndex <= options.Count)
                {
                    switch (selectedIndex)
                    {
                        case 1:
                            Patron.UserInformation();
                            break;
                        case 2:
                            PatronsBorrowMenu BorrowMenu = new PatronsBorrowMenu(Borrows, Patron, Books, Fines);
                            BorrowMenu.PatronBooksMenu();
                            break;
                        case 3:
                            PatronSearchMenu SearchMenu = new PatronSearchMenu(Books);
                            SearchMenu.PatronSearchMenuOptions();
                            break;
                        case 4:
                            Books.AvailableBooks();
                            break;    
                        case 5:
                            Console.WriteLine("Exiting the system. Goodbye!");
                            return;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                }
            }

    }
}