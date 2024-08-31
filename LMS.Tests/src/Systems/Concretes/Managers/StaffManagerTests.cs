using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;

public class StaffnManagerTests
{
    
    [Fact]
    public void AddStaff_ValidStaff_ShouldAddToList()
    {
        var staffManager = new StaffManager();
        var staff = new Staff("Polo", 1234567890, 123456, "Sud", "Polo123");

        staffManager.AddStaff(staff);

        var staffs = staffManager.GetStaffs();
        Assert.Contains(staff, staffs);
    }

    [Fact]
    public void UpdateStaff_ValidData_ShouldUpdateStaff()
    {
        var staffManager = new StaffManager();
        var staff = new Staff("John Doe", 1234567890, 123456, "123 Main St", "Password123");

        staffManager.AddStaff(staff);
        staffManager.UpdateStaff("John Doe", newName: "Jane Doe", newPhoneNumber: 124456);

        var updatedStaff = staffManager.GetStaffs().Find(p => p.getName() == "Jane Doe");

        Assert.NotNull(updatedStaff);
        Assert.Equal(124456, updatedStaff.getPhoneNumber());
    }

    [Fact]
    public void RemoveStaff_ExistingStaff_ShouldRemoveFromList()
    {
        var staffManager = new StaffManager();
        var staff = new Staff("John Doe", 1234567890, 123456, "123 Main St", "Password123");

        staffManager.AddStaff(staff);
        staffManager.RemoveStaff("John Doe");

        var staffs = staffManager.GetStaffs();
        Assert.DoesNotContain(staff, staffs);
    }

    [Fact]
    public void ValidateStaff_ValidCredentials_ShouldReturnStaff()
    {
        var staffManager = new StaffManager();
        var staff = new Staff("John Doe", 1234567890, 123456, "123 Main St", "Password123");

        staffManager.AddStaff(staff);

        var validatedStaff = staffManager.ValidateStaff("John Doe", "Password123");

        Assert.NotNull(validatedStaff);
        Assert.Equal(staff, validatedStaff);
    }
}   
