namespace searchSystem;

using userSystem;
using userSystem.Concrete;

public class PatronSearch{
    PatronManager PatronsList;
    public PatronSearch(PatronManager patronsList)
    {
        this.PatronsList = patronsList;
    }

    public void SearchPatronByName(string name)
    {
        List<Patron> result = new List<Patron>();
        foreach (Patron patron in PatronsList.GetPatrons())
        {
            if (patron.getName().Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(patron);
            }
        }
        SearchResult(result);
    }

    public void SearchPatronByMembershipNumber(int membershipNumber)
    {
        List<Patron> result = new List<Patron>();
        foreach (Patron patron in PatronsList.GetPatrons())
        {
            if (patron.getMemberShipNumber() == membershipNumber)
            {
                result.Add(patron);
            }
        }
        SearchResult(result);
    }

    public void SearchResult(List<Patron> PatronsResult)
    {
        foreach (Patron patron in PatronsResult)
        {
            patron.UserInformation();    
        }        
    }
}