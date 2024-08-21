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
        string patronName = patron.Name;
        if(FoundPatronByName(patronName) == null){
        PatronsList.Add(patron);
        Console.WriteLine($"Patron with name '{patron.Name}' has been added.");
        }
    }
    public void UpdatePatron(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
    {
        Patron? patron = FoundPatronByName(name);
        if(patron != null){
            if (!string.IsNullOrEmpty(newName))
            {
                patron.Name = newName;
            }
            if (newMembershipNumber.HasValue)
            {
                patron.MemberShipNumber = newMembershipNumber.Value;
            }
            if (newPhoneNumber.HasValue)
            {
            patron.PhoneNumber = newPhoneNumber.Value;
            }
            if (!string.IsNullOrEmpty(newDirection))
            {
            patron.Direction = newDirection;
            }
            if (!string.IsNullOrEmpty(newPassword))
            {
            patron.Password = newPassword;
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
                string patronName = patron.Name;
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
                string patronName = patron.Name;
                string patronPassword = patron.Password;
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
