using LMS.DataAccess.Systems.Concretes.Managers;

namespace LMS.DataAccess.Console.UserMenu;

public abstract class UserMenuTemplate
{
    protected BorrowManager _borrows;
    protected BookManager _books;
    protected FineManager _fines;
    public UserMenuTemplate(BorrowManager _borrows, BookManager _books, FineManager _fines)
    {
        this._borrows = _borrows;
        this._books = _books;
        this._fines = _fines;
    }

    public abstract void UserMenu();
}
