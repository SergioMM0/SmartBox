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
    private bool test = false;
    
    public ApplicationServiceBox(IBoxRepository repository, IMapper mapper, IValidator<PostBoxDTO> postValidator)
    {
        _mapper = mapper;
        _boxRepository = repository;
        _postValidator = postValidator;
    }

    public List<Box> GetAllBoxes()
    {
        if (test)
        {
            return _boxRepository.GetAllBoxesSample();
        }

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

    public List<Box> getAllBoxesFromDb()
    {
        return _boxRepository.GetAllBoxes();
    }
}