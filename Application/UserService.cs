using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<PostUserDTO> _postValidator;
    private readonly IValidator<PutUserDTO> _putValidator;
    private readonly IValidator<UserDTO> _userValidator;

    public UserService(
        IUserRepository repository,
        IMapper mapper,
        IValidator<PostUserDTO> postValidator,
        IValidator<PutUserDTO> putValidator,
        IValidator<UserDTO> userValidator)
    {
        _repository = repository;
        _mapper = mapper;
        _postValidator = postValidator;
        _putValidator = putValidator;
        _userValidator = userValidator;
    }
    
    public ICollection<User> GetAllUsers()
    {
        return _repository.GetAllUsers();
    }

    public User CreateNewUser(PostUserDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }
        return _repository.CreateNewUser(_mapper.Map<User>(dto));
    }

    public User GetUserById(int id)
    {
        return _repository.GetUserById(id);
    }

    public User UpdateUser(int id, PutUserDTO putUserDto)
    {
        var validation = _putValidator.Validate(putUserDto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }

        if (id != putUserDto.Id)
        {
            throw new ValidationException("ID in body and route are different");
        }
        
        return _repository.UpdateUser(_mapper.Map<User>(putUserDto));
    }

    public User DeleteUser(int id)
    {
        return _repository.DeleteUser(id);
    }

    public User AuthenticateUser(PostUserDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }

        return _repository.AuthenticateUser(_mapper.Map<User>(dto));
    }
}