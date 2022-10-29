namespace Application.DTOs;

public class PutUserDTO
{
    public int id { get; set; }
    public string Name { get; set; }
    
    public string? Address { get; set; }
    
    public string? Password { get; set; }
    
}