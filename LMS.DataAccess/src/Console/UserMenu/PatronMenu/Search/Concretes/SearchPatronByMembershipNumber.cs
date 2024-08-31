using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Services.Searchers;
using LMS.DataAccess.Services.Searchers.PatronSearchers.Concretes;
using LMS.DataAccess.Systems.Concretes.Managers;

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
            ErrorHandler.HandleError(new InvalidInputException("Invalid membership number. Please enter a valid number."));
        }
    }
}
