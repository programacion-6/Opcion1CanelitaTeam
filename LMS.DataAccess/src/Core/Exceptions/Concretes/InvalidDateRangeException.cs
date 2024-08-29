using LMS.DataAccess.Core.Exceptions.Abstracts;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions.Concretes;

public class InvalidDateRangeException : BaseException
{
    public InvalidDateRangeException(string message) 
    : base(message, Severity.HIGH)
    {
    }    
}
