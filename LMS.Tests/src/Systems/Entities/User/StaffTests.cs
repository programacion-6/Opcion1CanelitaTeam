using LMS.DataAccess.Systems.Entities.User;

public class StaffTests
{
    [Fact]
    public void Staff_Creation_Test()
    {
        var staff = new Staff("John Doe", 12345, 5551234, "123 Main St", "password123");

        Assert.Equal("John Doe", staff.getName());
        Assert.Equal(12345, staff.getMemberShipNumber());
        Assert.Equal(5551234, staff.getPhoneNumber());
        Assert.Equal("123 Main St", staff.getDirection());
        Assert.Equal("password123", staff.getPassword());
    }

    [Fact]
    public void Set_Name_Test()
    {
        var staff = new Staff("John Doe", 12345, 5551234, "123 Main St", "password123");
        staff.setName("Jane Doe");

        Assert.Equal("Jane Doe", staff.getName());
    }

    [Fact]
    public void Set_MemberShipNumber_Test()
    {
        var staff = new Staff("John Doe", 12345, 5551234, "123 Main St", "password123");
        staff.setMemberShipNumber(54321);

        Assert.Equal(54321, staff.getMemberShipNumber());
    }

    [Fact]
    public void Set_PhoneNumber_Test()
    {
        var staff = new Staff("John Doe", 12345, 5551234, "123 Main St", "password123");
        staff.setPhoneNumber(5554321);

        Assert.Equal(5554321, staff.getPhoneNumber());
    }

    [Fact]
    public void Set_Direction_Test()
    {
        var staff = new Staff("John Doe", 12345, 5551234, "123 Main St", "password123");
        staff.setDirection("456 Elm St");

        Assert.Equal("456 Elm St", staff.getDirection());
    }

    [Fact]
    public void Set_Password_Test()
    {
        var staff = new Staff("John Doe", 12345, 5551234, "123 Main St", "password123");
        staff.setPassword("newpassword456");

        Assert.Equal("newpassword456", staff.getPassword());
    }

}
