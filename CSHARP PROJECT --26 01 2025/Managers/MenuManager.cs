namespace ConsoleApp1.Managers;
using ConsoleApp1.Models;

class MenuManager
{
    private ShowroomManager _showroomManager;
    private SaleManager _saleManager;
    private UserManager _userManager;
    private DataManager _dataManager;

    public MenuManager(ShowroomManager showroomManager, SaleManager saleManager, UserManager userManager, 
        DataManager dataManager)
    {
        _showroomManager = showroomManager;
        _saleManager = saleManager;
        _userManager = userManager;
        _dataManager = dataManager;
    }

    public void ShowShowroomMenu()
    {
        Console.WriteLine("1. Add Showroom");
        Console.WriteLine("2. Edit Showroom");
        Console.WriteLine("3. Delete Showroom");
        Console.WriteLine("4. Back");
        Console.Write("Choose an option: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                _showroomManager.AddShowroom();
                break;
            case 2:
                _showroomManager.ShowroomEdit();
                break;
            case 3:
                _showroomManager.ShowroomDelete();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    public void ShowCarMenu()
    {
        var showroom = SelectShowroom();
        
        if (showroom == null)
        {
            Console.WriteLine("Showroom not found.");
            return;
        }
        
        Console.WriteLine("1. Add Car");
        Console.WriteLine("2. Edit Car");
        Console.WriteLine("3. Remove Car");
        Console.WriteLine("4. Back");
        Console.Write("Choose an option: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                showroom.AddCar();
                break;
            case 2:
                showroom.EditCar();
                break;
            case 3:
                showroom.RemoveCar();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    public void SellCar()
    {
        var showroom = SelectShowroom();
        
        if (showroom == null)
        {
            Console.WriteLine("Showroom not found.");
            return;
        }
        
        showroom.SellCarToCustomer(Guid.NewGuid(), _userManager, _showroomManager, _dataManager, _saleManager);
    }

    public void ShowSalesStatsMenu()
    {
        Console.WriteLine("1. Sales by Day");
        Console.WriteLine("2. Sales by Week");
        Console.WriteLine("3. Sales by Month");
        Console.WriteLine("4. Sales by Year");
        Console.WriteLine("5. Back");
        Console.Write("Choose an option: ");
        
        if (!int.TryParse(Console.ReadLine(), out var choice))
        {
            Console.WriteLine("Invalid input.");
            return;
        }

        Console.Write("Enter the date (yyyy-mm-dd): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Invalid date format.");
            return;
        }

        switch (choice)
        {
            case 1:
                _saleManager.ShowSalesStatsByDay(date);
                break;
            case 2:
                _saleManager.ShowSalesStatsByWeek(date);
                break;
            case 3:
                _saleManager.ShowSalesStatsByMonth(date);
                break;
            case 4:
                _saleManager.ShowSalesStatsByYear(date);
                break;
            case 5:
                break;
        }
    }
    
    private Showroom SelectShowroom()
    {
        if (!_showroomManager.Showrooms.Any())
        {
            Console.WriteLine("No showrooms available. Please create one.");
            return null;
        }

        Console.WriteLine("\nList of showrooms:");
        for (int i = 0; i < _showroomManager.Showrooms.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_showroomManager.Showrooms[i].Name} (Capacity:" +
                              $" {_showroomManager.Showrooms[i].CarCapacity})");
        }

        Console.Write("Choose a showroom: ");
        if (int.TryParse(Console.ReadLine(), out var index) &&
            index > 0 && index <= _showroomManager.Showrooms.Count)
        {
            return _showroomManager.Showrooms[index - 1];
        }

        Console.WriteLine("Invalid showroom selection.");
        return null;
    }
}
