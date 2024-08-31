using LMS.DataAccess.Services.Searchers.PatronSearchers.Abstracts;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;


namespace LMS.DataAccess.Services.Searchers.PatronSearchers.Concretes;

public class PatronSearchByMembershipNumber : PatronSearchTemplate<int>
{
    public PatronSearchByMembershipNumber(PatronManager patronManager) : base(patronManager) { }

    protected override List<Patron> Search(int membershipNumber)
    {
        List<Patron> result = new List<Patron>();
        foreach (Patron patron in Repository.GetAll())
        {
            if (patron.getMemberShipNumber() == membershipNumber)
            {
                result.Add(patron);
            }
        }
        return result;
    }
}
