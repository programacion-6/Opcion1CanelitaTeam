using LMS.DataAccess.Services.Searchers.PatronSearchers.Abstracts;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;

namespace LMS.DataAccess.Services.Searchers.PatronSearchers.Concretes;

public class PatronSearchByName : PatronSearchTemplate<string>
{
    public PatronSearchByName(PatronManager patronManager) : base(patronManager) { }

    protected override List<Patron> Search(string name)
    {
        List<Patron> result = new List<Patron>();
        foreach (Patron patron in Repository.GetAll())
        {
            if (patron.getName().Equals(name, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(patron);
            }
        }
        return result;
    }
}
