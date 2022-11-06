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
    
    public User GetUserById(int id)
    {
        return _context.UserTable.Find(id) ?? throw new KeyNotFoundException();
    }

    public User UpdateUser(User user)
    {
        var userToUpdate = _context.UserTable.Find(user.Id) ?? throw new KeyNotFoundException();
        userToUpdate.Name = user.Name;
        userToUpdate.Password = user.Password;
        _context.UserTable.Attach(userToUpdate);
        _context.SaveChanges();
        return user;
    }

    public User DeleteUser(int id)
    {
        var userToDelete = _context.UserTable.Find(id) ?? throw new KeyNotFoundException();
        _context.UserTable.Remove(userToDelete);
        _context.SaveChanges();
        return userToDelete;
    }

    public User AuthenticateUser(User user)
    {
        var userAuth = _context.UserTable.FirstOrDefault(u => u.Name == user.Name) ?? throw new KeyNotFoundException();
        if (userAuth.Password == user.Password)
        {
            return userAuth;
        }

        throw new Exception("User and password doesn't match");
    }
}