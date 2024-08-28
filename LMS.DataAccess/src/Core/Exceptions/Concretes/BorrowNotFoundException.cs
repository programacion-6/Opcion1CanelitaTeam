using LMS.DataAccess.Core.Exceptions.Abstracts;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions.Concretes;

public class BorrowNotFoundException : BaseException
{
    public BorrowNotFoundException(string message) 
    : base(message, Severity.LOW)
    {
    }
}
