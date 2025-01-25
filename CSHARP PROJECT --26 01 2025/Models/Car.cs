namespace ConsoleApp1.Models;

public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public DateTime Year { get; set; }
    public Guid Id { get; set; } = Guid.NewGuid();
}