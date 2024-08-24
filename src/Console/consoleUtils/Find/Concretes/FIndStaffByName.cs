using userSystem;
using userSystem.Concrete;
using Utils;

public class FindStaffByName : FindProcess
{
    List<Staff> _staffs;
    string criteria;
    public FindStaffByName (List<Staff> _staffs, string criteria)
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
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while searching for the staff: {ex.Message}");
        }
        throw new InvalidOperationException("The requested item was not found.");;   
    }
}