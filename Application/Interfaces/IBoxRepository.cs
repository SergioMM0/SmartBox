using Domain;

namespace Application.Interfaces;

public interface IBoxRepository
{
    public List<Box> GetAllBoxes();
}