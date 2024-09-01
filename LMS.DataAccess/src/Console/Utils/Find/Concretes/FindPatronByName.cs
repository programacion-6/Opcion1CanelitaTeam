using LMS.DataAccess.Console.Utils.Find.Interfaces;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Utils;

namespace LMS.DataAccess.Console.Utils.Find.Concretes;

public class FindPatronByName : FindProcess
{
    List<Patron> _patrons;
    string criteria;
    public FindPatronByName(List<Patron> _patrons, string criteria)
    {
        this._patrons = _patrons;
        this.criteria = criteria;
    }
    public object FindItem()
    {
        try
        {
            foreach (Patron patron in _patrons)
            {
                string staffName = patron.getName();
                if (StringComparator.compare(staffName, criteria))
                {
                    return patron;
                }
            }
            ErrorHandler.HandleError(new InvalidInputException("The requested item was not found."));
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An error occurred while searching for the staff: {ex.Message}");
        } 
        return null;
    }
}
