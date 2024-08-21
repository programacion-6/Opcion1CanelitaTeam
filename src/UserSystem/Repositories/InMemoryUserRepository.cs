using Interfaces;

namespace Repositories;

public class InMemoryUserRepository : IUserRepository
{
    private List<User> _users;

    public InMemoryUserRepository()
    {
        _users = new List<User>();
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }

    public User GetUserByName(string name)
    {
        return _users.FirstOrDefault(u => u.Name == name);
    }

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUserByName(user.Name);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.MemberShipNumber = user.MemberShipNumber;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Direction = user.Direction;
            existingUser.Password = user.Password;
        }
    }

    public void RemoveUser(string name)
    {
        var user = GetUserByName(name);
        if (user != null)
        {
            _users.Remove(user);
        }
    }
}
