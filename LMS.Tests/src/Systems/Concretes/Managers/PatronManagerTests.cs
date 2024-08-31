using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;

public class PatronManagerTests
{
    
    [Fact]
    public void AddPatron_ValidPatron_ShouldAddToList()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("Polo", 1234567890, 123456, "Sud", "Polo123");

        patronManager.addPatron(patron);

        var patrons = patronManager.GetPatrons();
        Assert.Contains(patron, patrons);
    }

    [Fact]
    public void UpdatePatron_ValidData_ShouldUpdatePatron()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 1234567890, 123456, "123 Main St", "Password123");

        patronManager.addPatron(patron);
        patronManager.UpdatePatron("John Doe", newName: "Jane Doe", newPhoneNumber: 124456);

        var updatedPatron = patronManager.GetPatrons().Find(p => p.getName() == "Jane Doe");

        Assert.NotNull(updatedPatron);
        Assert.Equal(124456, updatedPatron.getPhoneNumber());
    }

    [Fact]
    public void RemovePatron_ExistingPatron_ShouldRemoveFromList()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 1234567890, 123456, "123 Main St", "Password123");

        patronManager.addPatron(patron);
        patronManager.RemovePatron("John Doe");

        var patrons = patronManager.GetPatrons();
        Assert.DoesNotContain(patron, patrons);
    }

    [Fact]
    public void ValidatePatron_ValidCredentials_ShouldReturnPatron()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 1234567890, 123456, "123 Main St", "Password123");

        patronManager.addPatron(patron);

        var validatedPatron = patronManager.ValidatePatron("John Doe", "Password123");

        Assert.NotNull(validatedPatron);
        Assert.Equal(patron, validatedPatron);
    }
}   
