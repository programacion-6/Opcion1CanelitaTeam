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
        Console.WriteLine("No Patron found.");
    }

    protected abstract override List<Patron> Search( T criterion);
}