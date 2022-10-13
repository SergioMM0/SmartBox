using Application.Interfaces;
using Domain;
using Domain.Interfaces;

namespace Application;

public class ApplicationServiceBox : IBoxService
{
    private IBoxRepository _boxRepository;
    
    public ApplicationServiceBox(IBoxRepository repository)
    {
        _boxRepository = repository;
    }

    public List<Box> GetAllBoxes()
    {
        return _boxRepository.GetAllBoxes();
    }
}