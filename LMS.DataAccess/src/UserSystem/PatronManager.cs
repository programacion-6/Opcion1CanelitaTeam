using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;
using LMS.DataAccess.UserSystem.Concretes;
using LMS.DataAccess.Utils;

namespace LMS.DataAccess.UserSystem;

public class PatronManager{
    List<Patron> PatronsList;

    public PatronManager()
    {
        PatronsList = new List<Patron>();    
    }

    public void addPatron (Patron patron)
    {
        string patronName = patron.getName();
        Patron? patronaux = (Patron)PerformFind.Execute(new FindPatronByName(PatronsList, patronName));
        if(patronaux == null){
        PatronsList.Add(patron);
        Console.WriteLine($"Patron with name '{patron.getName}' has been added.");
        }
    }
    public void UpdatePatron(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
    {
        Patron? patron = (Patron)PerformFind.Execute(new FindPatronByName(PatronsList, name));
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
        Patron? patron = (Patron)PerformFind.Execute(new FindPatronByName(PatronsList, name));
        if(patron!= null){
            PatronsList.Remove(patron);
            Console.WriteLine($"Patron with name '{name}' has been removed.");
        }       
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