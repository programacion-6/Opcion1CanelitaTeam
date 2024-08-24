using SearchSystem;
using userSystem;
using userSystem.Concrete;

public class SearchPatronByMembershipNumberInput : SearchInput
{
    PatronManager _patrons;

    public SearchPatronByMembershipNumberInput(PatronManager _patrons)
    {
        this._patrons = _patrons;
    }
    public void SearchByInput()
    {
        Console.Write("Enter the Membership Number of the Patron: ");
        string? input = Console.ReadLine();
        int patronMemberShip;
        if (int.TryParse(input, out patronMemberShip))
        {
            PerformSearch.Search(new PatronSearchByMembershipNumber(_patrons), patronMemberShip);
        }
        else
        {
            Console.WriteLine("Invalid membership number. Please enter a valid number.");
        }
    }
}