using Application.DTOs;
using Domain;

namespace Application.Interfaces;

public interface IUserService
{
    public ICollection<User> GetAllUsers();
    public User CreateNewUser(PostUserDTO dto);

    public User GetUserById(int id);
    public User UpdateUser(int id, PutUserDTO putUserDto);
    public User DeleteUser(int id);
}