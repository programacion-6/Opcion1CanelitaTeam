using BookSystem;
using BorrowSystem;
using LibraryConsole.PatronMenuOtions;
using LibraryMenu;
using userSystem;
using userSystem.Concrete;
using FinesSystem;
namespace LibraryConsole.Login;

public class Login{
    PatronManager Patrons;
    StaffManager Staffs;
    BorrowManager Borrows;
    BookManager Books;
    FineManager Fines;

    public Login (PatronManager patrons, StaffManager staffs, BorrowManager borrows, BookManager books, FineManager fines)
    {
        this.Patrons = patrons;
        this.Staffs = staffs;
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    public void LoginMenu()
        {
            Console.WriteLine("===== Login =====");
            Console.Write("Enter Username: ");
            string? username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string? password = Console.ReadLine();
            if(username != null && password != null){
                Staff? staff = Staffs.ValidateStaff(username, password);
                if (staff != null)
                {
                    Console.WriteLine($"Welcome, {staff.getName()} (Staff)!");
                    StaffMenu(staff);
                    return;
                }

                Patron? patron = Patrons.ValidatePatron(username, password);
                if (patron != null)
                {
                    Console.WriteLine($"Welcome, {patron.getName()} (Patron)!");
                    PatronMenu(patron);
                    return;
                }
            }
            

            Console.WriteLine("Invalid username or password. Please try again.");
            WelcomeMenu menu = new WelcomeMenu(Patrons, Staffs , Borrows, Books, Fines);
            menu.ShowMenu();
        }

        private void StaffMenu(Staff staff)
        {
            StaffMenu StaffOptions = new StaffMenu(staff, Borrows, Books, Patrons, Fines);
            StaffOptions.ShowStaffMenu();
        }

        private void PatronMenu(Patron patron)
        {
            PatronMenu PatronOptions = new PatronMenu(patron, Borrows, Books, Fines);
            PatronOptions.ShowPatronMenu();
        }
}