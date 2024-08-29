namespace LMS.DataAccess.Systems.Entities.User;

public interface UserCreator
{
    public User CreateUser(string Name, int MemberShipNumber, int PhoneNumber, string Direction, string Password);
}
