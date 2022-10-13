using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    public List<Box> GetAllBoxes()
    {
        return new List<Box>() { new Box(){Id = 1, Length = 2.1, Material = "Steel", Price = 5.95, Width = 3} };
    }

    public Box CreateNewBox(Box box)
    {
        return box;
    }
}