using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Core.Logs;
using LMS.DataAccess.Systems.Entities;
using LMS.DataAccess.Systems.Interfaces;

using Spectre.Console;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class FineManager : IBaseManager<Fine>
{
    List<Fine> Fines;
    private readonly ILogService _logService;

    public FineManager()
    {
        Fines = new List<Fine>();
        _logService = new LogService();
    }

    public bool Add(Fine fine)
    {
        try
        {
            if (Fines.Exists(f => f.GetBorrow().Equals(fine.GetBorrow())))
            {
                ErrorHandler.HandleError(new FineAlreadyExistsException("A fine already exists for this borrow record."));
            }

            Fines.Add(fine);
            return true;
        }
        catch (FineAlreadyExistsException ex)
        {
            System.Console.WriteLine(ex.Message);
            return false;
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("An unexpected error occurred while adding a fine.");
            _logService.LogError(Severity.MEDIUM, $"{ex.Message}");
            return false;
        }
    }

    public void FinesFromUser(string userName)
    {
        foreach (Fine fine in Fines)
        {
            if (fine.GetBorrow().GetPatron().getName().Equals(userName))
            {
                fine.FineDetails();
            }
        }
    }

    public List<Fine> GetAll() => this.Fines;

    public bool Update(Fine fine)
    {
        var patronName = AnsiConsole.Ask<string>("Enter the name of the patron:");
        var title = AnsiConsole.Ask<string>("Enter the name of the book:");
        var fineToUpdate = Fines.Find(
            fine => fine.GetBorrow().GetPatron().getName().Equals(patronName, StringComparison.OrdinalIgnoreCase) &&
            fine.GetBorrow().GetBook().Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (fineToUpdate != null)
        {
            fineToUpdate.SetPaid(fine.GetPaid());
            return true;
        }
        return false;
    }

    public bool Remove(Fine fine)
    {
        var patronName = AnsiConsole.Ask<string>("Enter the name of the patron:");
        var title = AnsiConsole.Ask<string>("Enter the name of the book:");

        var fineToRemove = Fines.Find(
            f => f.GetBorrow().GetPatron().getName().Equals(patronName, StringComparison.OrdinalIgnoreCase) &&
                 f.GetBorrow().GetBook().Title.Equals(title, StringComparison.OrdinalIgnoreCase));

        if (fineToRemove != null)
        {
            Fines.Remove(fineToRemove);
            return true;
        }

        return false;
    }
}
