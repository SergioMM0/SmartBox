using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;

public class Box
{
    public int Id { get; set; }
    public string Material { get; set; }
    public double Price { get; set; }
    public double Length { get; set; }
    public double Width { get; set; } 
    
    public double Height { get; set; }
    public int? OrderId { get; set; }
    
    public Order? Order { get; set; }
}