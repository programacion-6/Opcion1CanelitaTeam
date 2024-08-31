using LMS.DataAccess.Core.Exceptions.Abstracts;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.Core.Exceptions.Concretes;

public class InvalidInputException : BaseException
{
    public InvalidInputException(string message) 
    : base(message, Severity.LOW)
    {
    }    
}
