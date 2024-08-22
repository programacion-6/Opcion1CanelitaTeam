using userSystem;
using userSystem.Concrete;

public class PatronSearchByMembershipNumber : PatronSearchTemplate <int>
{
    public PatronSearchByMembershipNumber(PatronManager patronManager) : base(patronManager) { }

    protected override List<Patron> Search(int membershipNumber)
    {
        List<Patron> result = new List<Patron>();
        foreach (Patron patron in Repository.GetPatrons())
        {
            if (patron.getMemberShipNumber() == membershipNumber)
            {
                result.Add(patron);
            }
        }
        return result;
    }
}
