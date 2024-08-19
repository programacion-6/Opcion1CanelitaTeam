namespace userSystem;

using userSystem.Concrete;
using Utils;

public class PatronManager{
    List<Patron> PatronsList;

    public PatronManager()
    {
        PatronsList = new List<Patron>();    
    }

    public void addPatron (Patron patron)
    {
        string patronName = patron.getName();
        if(FoundPatronByName(patronName) == null){
        PatronsList.Add(patron);
        Console.WriteLine($"Patron with name '{patron.getName}' has been added.");
        }
    }
    public void UpdatePatron(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
    {
        Patron? patron = FoundPatronByName(name);
        if(patron != null){
            if (!string.IsNullOrEmpty(newName))
            {
                patron.setName(newName);
            }
            if (newMembershipNumber.HasValue)
            {
                patron.setMemberShipNumber(newMembershipNumber.Value);
            }
            if (newPhoneNumber.HasValue)
            {
            patron.setPhoneNumber(newPhoneNumber.Value);
            }
            if (!string.IsNullOrEmpty(newDirection))
            {
            patron.setDirection(newDirection);
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
            patron.setPassword(newPassword);
            }
        }

    }

    public void RemovePatron (string name){
        Patron? patron = FoundPatronByName(name);
        if(patron!= null){
            PatronsList.Remove(patron);
            Console.WriteLine($"Patron with name '{name}' has been removed.");
        }       
    }

    private Patron? FoundPatronByName(string name)
    {
        try
        {
            foreach (Patron patron in PatronsList)
            {
                string patronName = patron.getName();
                if (StringComparator.compare(patronName, name))
                {
                    return patron;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while searching for the patron: {ex.Message}");
        }

        return null;
    }

    public Patron? ValidatePatron(string name, string password)
    {
        try
        {
            foreach (Patron patron in PatronsList)
            {
                string patronName = patron.getName();
                string patronPassword = patron.getPassword();
                if (StringComparator.compare(patronName, name) && StringComparator.compare(patronPassword, password))
                {
                    return patron;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Invalid credentials: {ex.Message}");
        }

        return null;
    }
    public List<Patron> GetPatrons() => PatronsList;
    public void SetPatrons(List<Patron> patronList) => this.PatronsList = patronList;

}