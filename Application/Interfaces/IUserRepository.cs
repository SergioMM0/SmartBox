using Domain;

namespace Application.Interfaces;

public interface IUserRepository
{
    public ICollection<User> GetAllUsers();
    public User CreateNewUser(User user);
    public User GetUserById(int id);
    public User UpdateUser(User user);
    public User DeleteUser(int id);

}