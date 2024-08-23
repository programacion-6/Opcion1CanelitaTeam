
using BookSystem;
using BorrowSystem;
using FinesSystem;

public abstract class UserMenu{
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