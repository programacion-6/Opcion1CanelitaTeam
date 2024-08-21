namespace Interfaces;

public interface IUserRepository
{
    List<User> GetAllUsers();
    User GetUserByName(string name);
    void AddUser(User user);
    void UpdateUser(User user);
    void RemoveUser(string name);
}
