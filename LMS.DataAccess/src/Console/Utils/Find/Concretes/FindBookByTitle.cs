using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Console.Utils.Find.Interfaces;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.Utils.Find.Concretes;

public class FindBookByTitle : FindProcess
{
    BookManager Books;
    string Criteria;
    public FindBookByTitle(BookManager Books, string criteria)
    {
        this.Books = Books;
        this.Criteria = criteria;
    }
    public Object FindItem()
    {
        var book = Books.GetAll().Find(b => b.Title == Criteria);
        if (book == null)
        {
            ErrorHandler.HandleError(new InvalidInputException($"No book found with title: {Criteria}"));
        }
        return book;
    }
}
