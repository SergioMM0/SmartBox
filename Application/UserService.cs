using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;

namespace Application;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<PostUserDTO> _postValidator;

    public UserService(
        IUserRepository repository,
        IMapper mapper,
        IValidator<PostUserDTO> postValidator
        )
    {
        _repository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
    }
    
    public ICollection<User> GetAllUsers()
    {
        throw new NotImplementedException();
    }

    public User CreateNewUser(User user)
    {
        throw new NotImplementedException();
    }

    public User UpdateUser(User user)
    {
        throw new NotImplementedException();
    }

    public User DeleteUser(User user)
    {
        throw new NotImplementedException();
    }
}