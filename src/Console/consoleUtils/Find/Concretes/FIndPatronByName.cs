using userSystem;
using userSystem.Concrete;
using Utils;

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
            Console.WriteLine($"An error occurred while searching for the staff: {ex.Message}");
        }
        throw new InvalidOperationException("The requested item was not found.");;   
    }
}