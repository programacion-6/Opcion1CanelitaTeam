using LMS.DataAccess.Systems.Entities.Borrowing;

namespace LMS.DataAccess.Services.Validators
{
    public class BorrowValidator
    {

        public bool ValidateBorrow(Borrow borrow)
        {
            return ValidateBorrowDate(borrow.GetBorrowDate()) &&
                   ValidateDueDate(borrow.GetDueDate(), borrow.GetBorrowDate());
        }

        public bool ValidateBorrowDate(DateTime borrowDate)
        {
            return borrowDate <= DateTime.Now;
        }

        public bool ValidateDueDate(DateTime dueDate, DateTime borrowDate)
        {
            return dueDate > borrowDate;
        }
    }
}
