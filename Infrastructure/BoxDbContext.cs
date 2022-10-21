using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class BoxDbContext: DbContext
{
    public BoxDbContext(DbContextOptions<BoxDbContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Box> BoxTable { get; set; }
}