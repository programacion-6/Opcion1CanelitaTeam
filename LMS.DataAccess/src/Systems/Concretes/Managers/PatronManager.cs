using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Services.Validators;
using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Systems.Interfaces;

using Spectre.Console;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class PatronManager : IBaseManager<Patron>
{
    private List<Patron> PatronsList;
    private PatronValidator _validator;

    public PatronManager()
    {
        PatronsList = new List<Patron>();
        _validator = new PatronValidator();
    }

    public bool Add(Patron patron)
    {
        if (_validator.ValidatePatron(patron) && !PatronExists(patron.getName()))
        {
            PatronsList.Add(patron);
            System.Console.WriteLine($"Patron '{patron.getName()}' added.");
            return true;
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException("Invalid patron data or patron already exists."));
            return false;
        }
    }

    public bool Update(Patron patron)
    {
        var patronName = AnsiConsole.Ask<string>("[gray] Enter the patron name to update:");
        var patronToUpdate = FindPatron(patronName);
        if (patronToUpdate != null)
        {
            patronToUpdate.setName(patron.getName());
            patronToUpdate.setPhoneNumber(patron.getPhoneNumber());
            patronToUpdate.setMemberShipNumber(patron.getMemberShipNumber());
            patronToUpdate.setDirection(patron.getDirection());
            return true;
        }
        else
        {
            ErrorHandler.HandleError(new InvalidInputException($"Patron '{patronName}'not found."));
            return false;
        }
    }

    public bool Remove(Patron patron)
    {
        if (patron != null && PatronsList.Contains(patron))
        {
            PatronsList.Remove(patron);
            System.Console.WriteLine($"Patron '{patron}' removed.");
            return true;
        }
        else
        {
            System.Console.WriteLine($"[ERROR] Patron '{patron}' not found.");
            return false;
        }
    }

    public Patron? ValidatePatron(string name, string password)
    {
        Patron? patron = FindPatron(name);
        return (patron != null && _validator.ValidatePassword(password)) ? patron : null;
    }
    public List<Patron> GetAll() => PatronsList;
    private Patron? FindPatron(string name) => PatronsList.Find(patron => patron.getName().Equals(name, StringComparison.OrdinalIgnoreCase));
    private bool PatronExists(string name) => FindPatron(name) != null;
}
