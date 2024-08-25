using LMS.DataAccess.Console.UserMenu.PatronMenu.Search.Interfaces;
using LMS.DataAccess.SearchSystem;
using LMS.DataAccess.SearchSystem.PatronSearch.Concretes;
using LMS.DataAccess.UserSystem;

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
        Console.Write("Enter the Name of the Patron: ");
        string? patronName = Console.ReadLine();
        if (!string.IsNullOrEmpty(patronName))
        {
            PerformSearch.Search(new PatronSearchByName(_patrons), patronName);    
        }
        else
        {
            Console.WriteLine("Title cannot be null or empty.");
        }
    }
}