using Application.Interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    //Testing without dbCon
    public List<Box> GetAllBoxesSample()
    {
        return new List<Box>() { new Box(1,2.1,2,3, "miscojones",3)};
    }

    public Box CreateNewBox(Box box)
    {
        return box;
    }

    //Actual repository with connection to the db

    //public DbContextOptions<DbContext> _opts;
    private readonly DbContext _context;
    public BoxRepository(DbContext context)
    {
        _context = context;

        /*
        _opts = new DbContextOptionsBuilder<DbContext>()
            .UseSqlite("Data source=../Infrastructure/db.db").Options;
            */
    }

    public List<Box> GetAllBoxes()
    {
        return _context.Box.ToList();
    }
}