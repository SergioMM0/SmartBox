using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Domain;

namespace Infrastructure;

public class DbContext: Microsoft.EntityFrameworkCore.DbContext
{
    
    public DbContext(DbContextOptions<DbContext> options, ServiceLifetime serviceLifetime) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
    }
    
    public DbSet<Box> Box { get; set; }
}