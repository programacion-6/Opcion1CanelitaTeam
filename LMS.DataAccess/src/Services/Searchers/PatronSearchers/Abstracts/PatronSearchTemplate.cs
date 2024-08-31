using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;

namespace LMS.DataAccess.Services.Searchers.PatronSearchers.Abstracts;

public abstract class PatronSearchTemplate<T> : SearchBase<PatronManager, Patron, T>
{
    public PatronSearchTemplate(PatronManager patronManager) : base(patronManager) { }

    protected override void DisplayDetails(Patron patron)
    {
        patron.UserInformation();
    }

    protected override void NoResultsFound()
    {
        ErrorHandler.HandleError(new PatronNotFoundException("No patrons found matching with the search criteria."));
    }

    protected abstract override List<Patron> Search(T criterion);
}
