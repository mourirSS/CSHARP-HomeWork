namespace ConsoleApp1.Managers;
using ConsoleApp1.Models;

class ShowroomManager
{
    public List<Showroom> Showrooms { get; set; } = new();
    
    public void DisplayAllShowrooms()
    {
        if (!Showrooms.Any())
        {
            Console.WriteLine("No showrooms available.");
            return;
        }

        Console.WriteLine("List of showrooms:");
        for (int i = 0; i < Showrooms.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Showrooms[i].Name} (Capacity: {Showrooms[i].CarCapacity})");
        }
    }

    
    public void AddShowroom()
    {
        Console.WriteLine("Write showroom's name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Write showroom's capacity: ");
        int.TryParse(Console.ReadLine(), out var capacity);

        var showroom = new Showroom
        {
            Name = name,
            CarCapacity = capacity
        };
        
        Showrooms.Add(showroom);
        Console.WriteLine($"Showroom {name} added successfully!");
    }

    public void ShowroomEdit()
    {
        if (Showrooms.Count == 0)
        {
            Console.WriteLine("Showroom is empty!");
            return;
        }

        DisplayAllShowrooms();
        
        Console.Write("Choose the number of showroom to edit: ");
        int.TryParse(Console.ReadLine(), out var index);

        if (index < 1 || index > Showrooms.Count)
        {
            Console.WriteLine("Invalid choice, please try again!");
            return;
        }
        
        var showroom = Showrooms[index - 1];

        Console.Write("Write new showroom's name: ");
        showroom.Name = Console.ReadLine();

        Console.Write("Write new capacity: ");
        int.TryParse(Console.ReadLine(), out var capacity);
        
        showroom.CarCapacity = capacity;
        Console.WriteLine("Showroom edited successfully!");
    }

    public void ShowroomDelete()
    {
        if (Showrooms.Count == 0)
        {
            Console.WriteLine("Showroom is empty!");
            return;
        }

        DisplayAllShowrooms();
        
        Console.Write("Choose the number of showroom to delete: ");
        int.TryParse(Console.ReadLine(), out var index);

        if (index < 1 || index > Showrooms.Count)
        {
            Console.WriteLine("Invalid choice, please try again!");
            return;
        }
        
        Showrooms.RemoveAt(index - 1);
        Console.WriteLine("Showroom deleted successfully!");
    }
}
