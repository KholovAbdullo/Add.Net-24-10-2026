namespace Domain.Models;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public decimal Price { get; set; }
    public int categoryId { get; set; }
}
