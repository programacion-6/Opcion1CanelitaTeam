using LMS.DataAccess.Systems.Concretes.Managers;

namespace LMS.DataAccess.Console.LoginMenu;

public abstract class UserMenu
{
    BorrowManager Borrows;
    BookRepository Books;
    FineManager Fines;

    public UserMenu(BorrowManager borrows, BookRepository books, FineManager fines)
    {
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    public abstract void ShowMenu();
}
