using LMS.DataAccess.Console.Utils.Find.Interfaces;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Utils;

namespace LMS.DataAccess.Console.Utils.Find.Concretes;

public class FindStaffByName : FindProcess
{
    List<Staff> _staffs;
    string criteria;
    public FindStaffByName(List<Staff> _staffs, string criteria)
    {
        this._staffs = _staffs;
        this.criteria = criteria;
    }
    public object FindItem()
    {
        try
        {
            foreach (Staff staff in _staffs)
            {
                string staffName = staff.getName();
                if (StringComparator.compare(staffName, criteria))
                {
                    return staff;
                }
            }
            ErrorHandler.HandleError(new InvalidInputException("The requested item was not found."));
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"An error occurred while searching for the staff: {ex.Message}");
        }
        throw new InvalidOperationException("The requested item was not found."); ;
    }
}
