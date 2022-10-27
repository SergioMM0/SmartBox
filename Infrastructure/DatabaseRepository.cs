using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class DatabaseRepository :IDatabaseRepository
{
    private readonly SmartBoxContext _context;
    
    public DatabaseRepository(SmartBoxContext context)
    {
        _context = context;
    }
    public void RebuildDb()
    {
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
}