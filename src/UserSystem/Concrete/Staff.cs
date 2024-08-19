namespace userSystem.Concrete;

public class Staff : User
{
    public Staff(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password) : base(Name, MemberShipNumber, PhoneNumber, Direction, Password)
    {
    }

    public override void UserInformation()
    {
        Console.WriteLine("========== Staff Information ==========");
        Console.WriteLine($"Name:               {Name}");
        Console.WriteLine($"Membership Number:  {MemberShipNumber}");
        Console.WriteLine($"Phone Number:       {PhoneNumber}");
        Console.WriteLine($"Direction:          {Direction}");
        Console.WriteLine("======================================");
    }
}