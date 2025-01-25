namespace ConsoleApp1.Managers;
using ConsoleApp1.Models;

class SaleManager
{
    public List<Sale> Sales = new(); //Все продажи
    
    //Добавление новой продажи
    public void AddSale(Guid showroomId, Guid carId, Guid userId, DateTime saleDate, decimal salePrice,
        string make, string model)
    {
        var sale = new Sale
        {
            ShowroomId = showroomId,
            CarId = carId,
            UserId = userId,
            SaleDate = saleDate,
            SalePrice = salePrice,
            Make = make,
            Model = model
        };
        Sales.Add(sale);
    }
    
    //Статистикак по продажам за период
    public void ShowSalesStats(DateTime startDate, DateTime endDate)
    {
        var filteredSales = Sales.Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate).ToList();
        if (!filteredSales.Any())
        {
            Console.WriteLine("No sales found!");
            return;
        }

        Console.WriteLine($"Sale stats since {startDate:yyyy-MM-dd} till {endDate:yyyy-MM-dd}:");
        foreach (var sale in filteredSales)
        {
            Console.WriteLine($"Sales' ID: {sale.Id}, Showroom's ID: {sale.ShowroomId}, Car's ID: {sale.CarId}, " +
                              $"Brand: {sale.Make}, Model: {sale.Model}, " +
                              $"Price: {sale.SalePrice}, Date: {sale.SaleDate:yyyy-MM-dd}");
        }
    }
    
    // Статистика по дням
    public void ShowSalesStatsByDay(DateTime day)
    {
        ShowSalesStats(day, day);
    }

    // Статистика по неделям
    public void ShowSalesStatsByWeek(DateTime startDate)
    {
        var endDate = startDate.AddDays(7);
        ShowSalesStats(startDate, endDate);
    }

    // Статистика по месяцам
    public void ShowSalesStatsByMonth(DateTime startDate)
    {
        var endDate = startDate.AddMonths(1);
        ShowSalesStats(startDate, endDate);
    }

    // Статистика по годам
    public void ShowSalesStatsByYear(DateTime startDate)
    {
        var endDate = startDate.AddYears(1);
        ShowSalesStats(startDate, endDate);
    }
}