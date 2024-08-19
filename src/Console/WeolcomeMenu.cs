using BookSystem;
using BorrowSystem;
using FinesSystem;
using LibraryConsole.Login;
using LibraryConsole.Utils;
using userSystem;

namespace LibraryMenu;

public class WelcomeMenu{
    PatronManager Patrons;
    StaffManager Staffs;
    BorrowManager Borrows;
    BookManager Books;
    FineManager Fines;

    public WelcomeMenu(PatronManager patrons, StaffManager staffs, BorrowManager borrows, BookManager books, FineManager fines)
    {
        this.Patrons = patrons;
        this.Staffs = staffs;
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    
        public void ShowMenu()
        {
            while (true)
            {
                List<string> options = new List<string> { "Login", "Exit" };
                MenuGenerator.genericMenu("Welcome to the Library System", options);

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        Login login = new Login(Patrons, Staffs, Borrows, Books, Fines);
                        login.LoginMenu();
                        break;
                    case "2":
                        Console.WriteLine("Exiting the system. Goodbye!");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
}

