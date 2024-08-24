using SearchSystem;
using userSystem;
using userSystem.Concrete;

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