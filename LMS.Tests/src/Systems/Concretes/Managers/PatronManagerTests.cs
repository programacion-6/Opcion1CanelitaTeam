using LMS.DataAccess.Systems.Entities.User;
using LMS.DataAccess.Systems.Concretes.Managers;

public class PatronManagerTests
{
    [Fact]
    public void Add_ValidPatron_ReturnsTrue()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 1234567890, 123456, "123 Main St", "Password123");

        bool result = patronManager.Add(patron);

        Assert.True(result);
        Assert.Contains(patron, patronManager.GetAll());
    }

    [Fact]
    public void Add_InvalidName_ReturnsFalse()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("JD", 1234567890, 123456, "123 Main St", "Password123");

        bool result = patronManager.Add(patron);

        Assert.False(result);
        Assert.DoesNotContain(patron, patronManager.GetAll());
    }

    [Fact]
    public void Add_InvalidMembershipNumber_ReturnsFalse()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 12345, 123456, "123 Main St", "Password123");

        bool result = patronManager.Add(patron);

        Assert.False(result);
        Assert.DoesNotContain(patron, patronManager.GetAll());
    }

    [Fact]
    public void Add_InvalidPhoneNumber_ReturnsFalse()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 1234567890, 12345, "123 Main St", "Password123");

        bool result = patronManager.Add(patron);

        Assert.False(result);
        Assert.DoesNotContain(patron, patronManager.GetAll());
    }

    [Fact]
    public void Add_InvalidPassword_ReturnsFalse()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 1234567890, 123456, "123 Main St", "pass");

        bool result = patronManager.Add(patron);

        Assert.False(result);
        Assert.DoesNotContain(patron, patronManager.GetAll());
    }

    [Fact]
    public void Remove_ValidPatron_ReturnsTrue()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("John Doe", 1234567890, 123456, "123 Main St", "Password123");
        patronManager.Add(patron);

        bool result = patronManager.Remove(patron);

        Assert.True(result);
    }

    [Fact]
    public void Remove_NonExistingPatron_ReturnsFalse()
    {
        var patronManager = new PatronManager();
        var patron = new Patron("NonExisting Patron", 1234567890, 123456, "123 Main St", "Pa123");

        bool result = patronManager.Remove(patron);

        Assert.False(result);
    }

}
