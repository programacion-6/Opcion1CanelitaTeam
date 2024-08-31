using LMS.DataAccess.Systems.Entities.User;

public class PatronTests
{
    [Fact]
    public void Patron_Creation_Test()
    {
        var patron = new Patron("Alice Smith", 67890, 5556789, "789 Maple Ave", "secretpass");

        Assert.Equal("Alice Smith", patron.getName());
        Assert.Equal(67890, patron.getMemberShipNumber());
        Assert.Equal(5556789, patron.getPhoneNumber());
        Assert.Equal("789 Maple Ave", patron.getDirection());
        Assert.Equal("secretpass", patron.getPassword());
    }

    [Fact]
    public void Set_Name_Test()
    {
        var patron = new Patron("Alice Smith", 67890, 5556789, "789 Maple Ave", "secretpass");
        patron.setName("Bob Johnson");

        Assert.Equal("Bob Johnson", patron.getName());
    }

    [Fact]
    public void Set_MemberShipNumber_Test()
    {
        var patron = new Patron("Alice Smith", 67890, 5556789, "789 Maple Ave", "secretpass");
        patron.setMemberShipNumber(98765);

        Assert.Equal(98765, patron.getMemberShipNumber());
    }

    [Fact]
    public void Set_PhoneNumber_Test()
    {
        var patron = new Patron("Alice Smith", 67890, 5556789, "789 Maple Ave", "secretpass");
        patron.setPhoneNumber(5559876);

        Assert.Equal(5559876, patron.getPhoneNumber());
    }

    [Fact]
    public void Set_Direction_Test()
    {
        var patron = new Patron("Alice Smith", 67890, 5556789, "789 Maple Ave", "secretpass");
        patron.setDirection("456 Oak St");

        Assert.Equal("456 Oak St", patron.getDirection());
    }

    [Fact]
    public void Set_Password_Test()
    {
        var patron = new Patron("Alice Smith", 67890, 5556789, "789 Maple Ave", "secretpass");
        patron.setPassword("newsecret123");

        Assert.Equal("newsecret123", patron.getPassword());
    }

}
