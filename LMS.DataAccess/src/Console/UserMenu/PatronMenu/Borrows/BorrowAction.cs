using LMS.DataAccess.Console.UserMenu.PatronMenu.Borrows.Interfaces;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;

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
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("No book found with that title"));
        }
    }
}
