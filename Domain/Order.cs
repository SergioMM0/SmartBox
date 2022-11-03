using System.ComponentModel.DataAnnotations.Schema;

namespace Domain;
public class Order
{
    public int Id { get; set; }
    public string DeliveryAddress { get; set; }
    
    public int UserId { get; set; }
    public User User { get; set; }
    
    public List<Box> BoxesOrdered { get; set; }
}