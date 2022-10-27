using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    public ICollection<User> GetAllUsers();
    public User CreateNewUser(User user);
    public User UpdateUser(User user);
    public User DeleteUser(User user);
}