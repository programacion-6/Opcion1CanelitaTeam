using LMS.DataAccess.BookSystem.Concretes;
using LMS.DataAccess.BorrowSystem;
using LMS.DataAccess.FineSystem;

namespace LMS.DataAccess.Console.UserMenu;

public abstract class UserMenuTemplate {
    protected BorrowManager _borrows;
    protected BookRepository _books;
    protected FineManager _fines;
    public UserMenuTemplate (BorrowManager _borrows, BookRepository _books, FineManager _fines) 
    {
        this._borrows = _borrows;
        this._books = _books;
        this._fines = _fines;
    }

    public abstract void UserMenu();
}