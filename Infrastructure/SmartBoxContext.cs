using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public class SmartBoxContext: DbContext
{
    public SmartBoxContext(DbContextOptions<SmartBoxContext> opts) : base(opts)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Box>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        
        /*
        //One to many relationship
        modelBuilder.Entity<Box>()
            .HasOne(f => f.Order)
            .WithMany(f => f.BoxesOrdered)
            .HasForeignKey(f => f.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
            
            */
        
        modelBuilder.Entity<User>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<User>()
            .Property(f => f.UserType)
            .HasDefaultValue(1); //Normal users will be identified with the value 1 && admins with 0 
        
        modelBuilder.Entity<Order>()
            .Property(f => f.Id)
            .ValueGeneratedOnAdd();
        
        //One to many relationship between Order and User (User can have many Orders)
        modelBuilder.Entity<Order>()
            .HasOne(o => o.User)
            .WithMany(u => u.Orders)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        //One to many relationship between Box and Order (Order can have many boxes)
        modelBuilder.Entity<Box>()
            .HasOne(b => b.Order)
            .WithMany(o => o.BoxesOrdered)
            .HasForeignKey(b => b.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
    }
    
    public DbSet<Box> BoxTable { get; set; }
    public DbSet<User> UserTable { get; set; }
    public DbSet<Order> OrdersTable { get; set; }
}