namespace Domain;
public class Order
{
    public int Id { get; set; }
    
    public int UserId { get; set; }
    
    public string DeliveryAddress { get; set; }
    
    public ICollection<Box> Boxes { get; set; }
    
    public User User { get; set; }
}