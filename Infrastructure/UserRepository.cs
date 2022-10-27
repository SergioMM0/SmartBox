using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class UserRepository : IUserRepository
{
    public readonly SmartBoxContext _context;

    public UserRepository(SmartBoxContext context)
    {
        _context = context;
    }
    
    public ICollection<User> GetAllUsers()
    {
        ICollection<User> allUsers = _context.UserTable.ToList();
        ICollection<User> onlyUsers = new List<User>();
        foreach (var user in allUsers)
        {
            if (user.UserType == 1)
            {
                onlyUsers.Add(user);
            }
        }
        return onlyUsers;
    }

    public User CreateNewUser(User user)
    {
        _context.UserTable.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User UpdateUser(User user)
    {
        _context.UserTable.Update(user);
        _context.SaveChanges();
        return user;
    }

    public User DeleteUser(User user)
    {
        _context.UserTable.Remove(user);
        _context.SaveChanges();
        return user;
    }
}