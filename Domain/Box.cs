namespace Domain;

public class Box
{
    public int Id { get; set; }
    public double Price { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    
    public double Height { get; set; }
    public string Material { get; set; }

    public Box(int id, double price, double length, double width, string material, double height)
    {
        Id = id;
        Price = price;
        Length = length;
        Width = width;
        Material = material;
        Height = height;
    }

    public Box()
    {
    }
}