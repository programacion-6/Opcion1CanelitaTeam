using LMS.DataAccess.SearchSystem.PatronSearch.Abstract;
using LMS.DataAccess.UserSystem;
using LMS.DataAccess.UserSystem.Concretes;

namespace LMS.DataAccess.SearchSystem.PatronSearch.Concretes;

public class PatronSearchByName : PatronSearchTemplate<string>
{
    public PatronSearchByName(PatronManager patronManager) : base(patronManager) { }

    protected override List<Patron> Search(string name)
    {
        List<Patron> result = new List<Patron>();
        foreach (Patron patron in Repository.GetPatrons())
        {
            if (patron.getName().Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(patron);
            }
        }
        return result;
    }
}
