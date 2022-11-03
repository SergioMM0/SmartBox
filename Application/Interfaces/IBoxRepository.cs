using Domain;

namespace Application.Interfaces;

public interface IBoxRepository
{
    public List<Box> GetAllBoxes();
    public Box CreateNewBox(Box box);
    public Box DeleteBox(int id);
}