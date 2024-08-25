using LMS.DataAccess.Console.Utils.Find.Interfaces;
using LMS.DataAccess.UserSystem.Concretes;
using LMS.DataAccess.Utils;

namespace LMS.DataAccess.Console.Utils.Find.Concretes;

public class FindPatronByName : FindProcess
{
    List<Patron> _patrons;
    string criteria;
    public FindPatronByName (List<Patron> _patrons, string criteria)
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
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An error occurred while searching for the staff: {ex.Message}");
        }
        throw new InvalidOperationException("The requested item was not found.");;   
    }
}