using LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Interfaces;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows;

public class BorrowAction
{

    BorrowInput? _Input;
    public void SetBorrow(BorrowInput input)
    {
        this._Input = input;
    }
    public void Execute()
    {
        if (_Input != null)
        {
            _Input.BorrowOption();
        }
    }
}
