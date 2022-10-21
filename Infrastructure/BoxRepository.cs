using Application.Interfaces;
using Domain;

namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    private readonly BoxDbContext _context;
    public BoxRepository(BoxDbContext context)
    {
        _context = context;
    }
    public void RebuildDb()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
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