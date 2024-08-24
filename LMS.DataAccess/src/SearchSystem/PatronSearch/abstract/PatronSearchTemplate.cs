using Core.Exceptions;
using userSystem;
using userSystem.Concrete;

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
