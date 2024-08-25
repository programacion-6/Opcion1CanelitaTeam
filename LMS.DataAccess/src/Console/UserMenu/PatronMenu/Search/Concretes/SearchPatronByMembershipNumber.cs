using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem;
using LMS.DataAccess.SearchSystem.PatronSearch.Concretes;
using LMS.DataAccess.UserSystem;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchPatronByMembershipNumberInput : SearchInput
{
    PatronManager _patrons;

    public SearchPatronByMembershipNumberInput(PatronManager _patrons)
    {
        this._patrons = _patrons;
    }
    public void SearchByInput()
    {
        System.Console.Write("Enter the Membership Number of the Patron: ");
        string? input = System.Console.ReadLine();
        int patronMemberShip;
        if (int.TryParse(input, out patronMemberShip))
        {
            PerformSearch.Search(new PatronSearchByMembershipNumber(_patrons), patronMemberShip);
        }
        else
        {
            System.Console.WriteLine("Invalid membership number. Please enter a valid number.");
        }
    }
}