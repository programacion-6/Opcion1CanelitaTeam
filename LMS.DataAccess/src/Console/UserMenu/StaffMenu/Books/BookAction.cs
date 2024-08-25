using LMS.DataAccess.Console.UserMenu.StaffMenu.Books.Interfaces;

namespace LMS.DataAccess.Console.UserMenu.StaffMenu.Books;

public class BookAction 
{
    BookInput? bookInput;
    public void setBookInput (BookInput input)
    {
        this.bookInput = input;
    }

    public void Execute()
    {
        if(bookInput != null)
        {
            bookInput.BookOption();
        }
    }
}