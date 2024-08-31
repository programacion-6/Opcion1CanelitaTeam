using LMS.DataAccess.Console.Utils.Find;
using LMS.DataAccess.Console.Utils.Find.Concretes;
using LMS.DataAccess.Core.Exceptions.Concretes;
using LMS.DataAccess.Core.Handlers;
using LMS.DataAccess.Services.Validators;
using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Utils;

namespace LMS.DataAccess.Systems.Concretes.Managers;

public class PatronManager
{
    private List<Patron> PatronsList;
    private PatronValidator _validator;

    public PatronManager()
    {
        PatronsList = new List<Patron>();
        _validator = new PatronValidator();
    }

    public void addPatron(Patron patron)
    {
         if (_validator.ValidatePatron(patron) && !PatronExists(patron.getName()))
            {
                PatronsList.Add(patron);
                System.Console.WriteLine($"Patron '{patron.getName()}' added.");
            }
            else
            {
                ErrorHandler.HandleError(new InvalidInputException("Invalid patron data or patron already exists."));
            }
        }
    public void UpdatePatron(string name, string? newName = null, int? newMembershipNumber = null, int? newPhoneNumber = null, string? newDirection = null, string? newPassword = null)
    {
        Patron? patron = FindPatron(name);
            if (patron == null)
            {
                ErrorHandler.HandleError(new InvalidInputException($"Patron '{name}' not found."));
                return;
            }

            Patron updatedPatron = new Patron(
                newName ?? patron.getName(),
                newMembershipNumber ?? patron.getMemberShipNumber(),
                newPhoneNumber ?? patron.getPhoneNumber(),
                newDirection ?? patron.getDirection(),
                newPassword ?? patron.getPassword()
            );

            if (_validator.ValidatePatron(updatedPatron))
            {
                PatronsList[PatronsList.IndexOf(patron)] = updatedPatron;
                System.Console.WriteLine($"Patron '{name}' updated.");
            }
            else
            {
                ErrorHandler.HandleError(new InvalidInputException($"Invalid data for patron '{name}'."));
            }

    }

    public void RemovePatron(string name)
    {
        Patron? patron = FindPatron(name);
            if (patron != null)
            {
                PatronsList.Remove(patron);
                System.Console.WriteLine($"Patron '{name}' removed.");
            }
            else
            {
                ErrorHandler.HandleError(new InvalidInputException($"Patron '{name}'not found."));
            }
    }

    public Patron? ValidatePatron(string name, string password)
        {
            Patron? patron = FindPatron(name);
            return (patron != null && _validator.ValidatePassword(password)) ? patron : null;
        }
    public List<Patron> GetPatrons() => PatronsList;
    private Patron? FindPatron(string name) =>
            (Patron?)PerformFind.Execute(new FindPatronByName(PatronsList, name));
    private bool PatronExists(string name) => FindPatron(name) != null;
    public void SetPatrons(List<Patron> patronList) => this.PatronsList = patronList;

}
