using LMS.DataAccess.Core.Exceptions;
using LMS.DataAccess.Core.Handlers;

namespace LMS.DataAccess.FineSystem;

public class FineManager
{
    List<Fine> Fines;
    private readonly ILogService _logService;
    
    public FineManager()
    {
        Fines = new List<Fine>();
        _logService = new LogService();
    }

    public void AddFine(Fine fine)
    {
        try
        {
            if (Fines.Exists(f => f.GetBorrow().Equals(fine.GetBorrow())))
            {
                throw new FineAlreadyExistsException("A fine already exists for this borrow record.");
            }
            
            Fines.Add(fine);
        }
        catch (FineAlreadyExistsException ex)
        {
            System.Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An unexpected error occurred while adding a fine.");
            _logService.LogError(Severity.MEDIUM, $"{ex.Message}");
        }
    }

    public void FinesFromUser(string userName){
        foreach(Fine fine in Fines){
            if(fine.GetBorrow().GetPatron().getName().Equals(userName)){
                fine.FineDetails();
            }
        }
    }

    public List<Fine> GetFines() => this.Fines;
}
