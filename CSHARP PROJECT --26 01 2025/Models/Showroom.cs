namespace ConsoleApp1.Models;
using ConsoleApp1.Managers;

class Showroom
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public List<Car> Cars { get; set; } = new List<Car>();
    public int CarCapacity { get; set; } 
    private int CarCount => Cars.Count; 
    
    public void DisplayAllCars()
    {
        if (!Cars.Any())
        {
            Console.WriteLine($"No cars available in showroom '{Name}'.");
            return;
        }

        Console.WriteLine($"List of cars in showroom '{Name}':");
        for (int i = 0; i < Cars.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Cars[i].Make} {Cars[i].Model} ({Cars[i].Year.Year})");
        }
    }
    
    
    //Продажа машины
    public void SellCarToCustomer(Guid userId, UserManager userManager, ShowroomManager showroomManager, 
        DataManager dataManager, SaleManager saleManager)
    {
        if (Cars.Count == 0)
        {
            Console.WriteLine("There are no cars in this showroom.");
            return;
        }

        DisplayAllCars();

        Console.Write("Choose the number of car: ");
        int.TryParse(Console.ReadLine(), out var index);

        if (index < 1 || index > Cars.Count)
        {
            Console.WriteLine("Wrong number, please try again!");
            return;
        }

        Console.Write("Write date of sale (yyyy-mm-dd): ");
        DateTime.TryParse(Console.ReadLine(), out DateTime saleDate);

        if (saleDate == default)
        {
            Console.WriteLine("Wrong date. Please enter a valid date in the format yyyy-mm-dd!");
            return;
        }

        Console.Write("Write the price of sale: ");
        decimal.TryParse(Console.ReadLine(), out var salePrice);

        if (salePrice <= 0)
        {
            Console.WriteLine("Wrong price. Please enter a valid price!");
            return;
        }

        var car = Cars[index - 1];
        Cars.RemoveAt(index - 1);

        // Регистрация продажи
        saleManager.AddSale(Id, car.Id, userId, saleDate, salePrice, car.Make, car.Model);

        // Сохраняем все данные
        dataManager.SaveAllData(userManager, showroomManager, saleManager);
        
        Console.WriteLine("Car sold successfully! Sale has been saved.");
    }

    public void AddCar()
    {
        if (CarCount >= CarCapacity)
        {
            Console.WriteLine($"Showroom is full! Max capacity is {CarCapacity} cars!");
            return;
        }

        Console.Write("Write brand's name: ");
        string make = Console.ReadLine();

        Console.Write("Write model: ");
        string model = Console.ReadLine();

        Console.Write("Write year (yyyy): ");
        int.TryParse(Console.ReadLine(), out var year);

        var newCar = new Car
        {
            Make = make,
            Model = model,
            Year = new DateTime(year)
        };

        Cars.Add(newCar);
        Console.WriteLine("Car added successfully!");
    }

    public void RemoveCar()
    {
        DisplayAllCars();

        Console.Write("Choose the number of car: ");
        int.TryParse(Console.ReadLine(), out var index);

        Cars.RemoveAt(index - 1);
        Console.WriteLine("Car removed successfully!.");
    }

    public void EditCar()
    {
        DisplayAllCars();
        
        Console.Write("Choose the number of car to edit: ");
        int.TryParse(Console.ReadLine(), out var index);
        
        var car = Cars[index - 1];

        Console.Write("Write new brand's name: ");
        car.Make = Console.ReadLine();

        Console.Write("Write new model: ");
        car.Model = Console.ReadLine();

        Console.Write("Write new year (yyyy): ");
        int.TryParse(Console.ReadLine(), out var year);
        car.Year = new DateTime(year);
        Console.WriteLine("The info is updated!.");
    }
}
