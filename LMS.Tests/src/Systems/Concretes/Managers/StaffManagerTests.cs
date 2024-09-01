using LMS.DataAccess.Systems.Concretes.Managers;
using LMS.DataAccess.Systems.Entities.User;

public class StaffManagerTests
{
    private StaffManager _staffManager;

    public StaffManagerTests()
    {
        _staffManager = new StaffManager();
    }

    private Staff CreateTestStaff()
    {
        return new Staff("John Doe", 1234567890, 123456, "123 Main St", "Password1");
    }

    [Fact]
    public void Add_ValidStaff_ReturnsTrue()
    {
        var staff = CreateTestStaff();

        var result = _staffManager.Add(staff);

        Assert.True(result);
        Assert.Single(_staffManager.GetAll());
    }

    [Fact]
    public void Add_DuplicateStaff_ReturnsFalse()
    {
        var staff = CreateTestStaff();
        _staffManager.Add(staff);

        var result = _staffManager.Add(staff);

        Assert.False(result);
    }

    [Fact]
    public void Remove_ValidStaff_ReturnsTrue()
    {
        var staff = CreateTestStaff();
        _staffManager.Add(staff);

        var result = _staffManager.Remove(staff);

        Assert.True(result);
        Assert.Empty(_staffManager.GetAll());
    }

    [Fact]
    public void Remove_NonExistentStaff_ReturnsFalse()
    {
        var staff = CreateTestStaff();

        var result = _staffManager.Remove(staff);

        Assert.False(result);
    }

}
