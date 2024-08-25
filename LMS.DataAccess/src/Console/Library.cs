using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.FineSystem;
using LMS.DataAccess.UserSystem;

namespace LMS.DataAccess.Console;

public class Library
{
    PatronManager Patrons;
    StaffManager Staffs;
    BorrowManager Borrows;
    BookRepository Books;
    FineManager Fines;

    public Library(PatronManager patrons, StaffManager staffs, BorrowManager borrows, BookRepository books, FineManager fines)
    {
        this.Patrons = patrons;
        this.Staffs = staffs;
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    public void InitializeProgram(){
        WelcomeMenu menu = new WelcomeMenu(Patrons, Staffs, Borrows, Books, Fines);
        menu.ShowMenu();
    }

}