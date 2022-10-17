using Application.Interfaces;
using Application.Validators;
using AutoMapper;
using Domain;
using Domain.Interfaces;
using FluentValidation;

namespace Application;

public class ApplicationServiceBox : IBoxService
{
    private IBoxRepository _boxRepository;
    private IMapper _mapper;
    private IValidator<PostBoxDTO> _postValidator;
    
    public ApplicationServiceBox(IBoxRepository repository, IMapper mapper, IValidator<PostBoxDTO> postValidator)
    {
        _mapper = mapper;
        _boxRepository = repository;
        _postValidator = postValidator;
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
}