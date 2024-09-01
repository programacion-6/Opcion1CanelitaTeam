using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.Services.Searchers.PatronSearchers.Concretes;
using LMS.DataAccess.Services.Searchers;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Exceptions.Concretes;

namespace LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Concretes;

public class SearchPatronByNameInput : SearchInput
{
    PatronManager _patrons;

    public SearchPatronByNameInput(PatronManager _patrons)
    {
        this._patrons = _patrons;
    }
    public void SearchByInput()
    {
        System.Console.Write("Enter the Name of the Patron: ");
        string? patronName = System.Console.ReadLine();
        if (!string.IsNullOrEmpty(patronName))
        {
            PerformSearch.Search(new PatronSearchByName(_patrons), patronName);
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Name cannot be null or empty."));
        }
    }
}
