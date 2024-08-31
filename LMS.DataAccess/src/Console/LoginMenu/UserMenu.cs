using LMS.DataAccess.Systems.Concretes.Managers;

namespace LMS.DataAccess.Console.LoginMenu;

public abstract class UserMenu
{
    BorrowManager Borrows;
    BookManager Books;
    FineManager Fines;

    public UserMenu(BorrowManager borrows, BookManager books, FineManager fines)
    {
        this.Borrows = borrows;
        this.Books = books;
        this.Fines = fines;
    }

    public abstract void ShowMenu();
}
