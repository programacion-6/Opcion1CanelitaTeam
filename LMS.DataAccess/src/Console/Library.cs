using System.ComponentModel.Design;
using BookSystem;
using BorrowSystem;
using FinesSystem;
using LibraryMenu;
using userSystem;

namespace LibraryConsole;
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