using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Application;

public class ApplicationServiceBox : IBoxService
{
    private readonly IBoxRepository _boxRepository;
    private readonly IMapper _mapper;
    private readonly IValidator<PostBoxDTO> _postValidator;
    private readonly IValidator<Box> _boxValidator;

    public ApplicationServiceBox(
        IBoxRepository repository,
        IMapper mapper, 
        IValidator<PostBoxDTO> postValidator,
        IValidator<Box> boxValidator)
    {
        _mapper = mapper;
        _boxRepository = repository;
        _postValidator = postValidator;
        _boxValidator = boxValidator;
    }

    public List<Box> GetAllBoxes()
    {
        return _boxRepository.GetAllBoxes();
    }
    public Box CreateNewBox(PostBoxDTO dto)
    {
        var validation = _postValidator.Validate(dto);
        if (!validation.IsValid)
        {
            throw new ValidationException(validation.ToString());
        }
        return _boxRepository.CreateNewBox(_mapper.Map<Box>(dto));
    }

    public Box DeleteBox(int id)
    {
        return _boxRepository.DeleteBox(id);
    }
}