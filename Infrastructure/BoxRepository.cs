using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    private readonly SmartBoxContext _context;
    public BoxRepository(SmartBoxContext context)
    {
        _context = context;
    }

    public List<Box> GetAllBoxes()
    {
        return _context.BoxTable.ToList();
    }

    public Box CreateNewBox(Box box)
    {
        _context.BoxTable.Add(box);
        _context.SaveChanges();
        return box;
    }
}