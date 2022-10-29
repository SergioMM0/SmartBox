namespace Domain;

public class User
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Password { get; set; }
    
    public string? Address { get; set; }
    
    public int UserType { get; set; }
}