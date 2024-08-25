using LMS.DataAccess.SearchSystem.PatronSearch.Abstract;
using LMS.DataAccess.UserSystem;
using LMS.DataAccess.UserSystem.Concretes;

namespace LMS.DataAccess.SearchSystem.PatronSearch.Concretes;

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
