using LMS.DataAccess.Core.Exceptions;
using LMS.DataAccess.UserSystem;
using LMS.DataAccess.UserSystem.Concretes;

namespace LMS.DataAccess.SearchSystem.PatronSearch.Abstract;

public abstract class PatronSearchTemplate <T> : SearchBase<PatronManager, Patron, T>
{
    public PatronSearchTemplate(PatronManager patronManager) : base(patronManager) { }

    protected override void DisplayDetails(Patron patron)
    {
        patron.UserInformation();
    }

    protected override void NoResultsFound()
    {
        throw new PatronNotFoundException("No patrons found matching with the search criteria.");
    }

    protected abstract override List<Patron> Search( T criterion);
}
