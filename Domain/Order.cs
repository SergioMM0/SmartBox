namespace Domain;
public class Order
{
    public int Id { get; set; }
    public ICollection<Box> BoxesOrdered { get; set; }
    
    public double TotalAmountToPay { get; set; }
    
    public int CustomerId { get; set; }
    
    public string Address { get; set; }
    
    public string CustomerName { get; set; }

    public Order()
    {
        if (BoxesOrdered.Count != 0)
            foreach (var box in BoxesOrdered)
            {
                TotalAmountToPay += box.Price;
            }
    }
    
}