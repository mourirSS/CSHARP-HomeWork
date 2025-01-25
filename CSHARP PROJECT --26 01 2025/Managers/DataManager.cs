namespace ConsoleApp1.Managers;
using ConsoleApp1.Models;
using System.Text.Json;
class DataManager
{
    private const string UserFile = "users.json";
    private const string ShowroomFile = "showrooms.json";
    public const string SalesFile = "sales.json";
    
    //Сохранение данных в файл
    public void SaveData<T>(string filePath, T data)
    {
        string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
        Console.WriteLine($"Data saved to {filePath}");
    }
    
    //Загрузка данных из файла
    public T LoadData<T>(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }
        return default;
    }
    
    //Сохранение всех данных
    public void SaveAllData(UserManager userManager, ShowroomManager showroomManager, SaleManager saleManager)
    {
        SaveData(UserFile, userManager.Users);
        SaveData(ShowroomFile, showroomManager.Showrooms);
        SaveData(SalesFile, saleManager.Sales);
    }
    
    //Загрузка всех данных из файла
    public void LoadAllData(UserManager userManager, ShowroomManager showroomManager, SaleManager saleManager)
    {
        userManager.Users = LoadData<List<User>>(UserFile) ?? new List<User>();
        showroomManager.Showrooms = LoadData<List<Showroom>>(ShowroomFile) ?? new List<Showroom>();
        saleManager.Sales = LoadData<List<Sale>>(SalesFile) ?? new List<Sale>();
    }
}