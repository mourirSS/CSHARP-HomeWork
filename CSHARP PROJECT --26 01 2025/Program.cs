using ConsoleApp1.Managers;
using ConsoleApp1.Models;


//Инициализируем всех менеджеров и данных
var userManager = new UserManager();
var saleManager = new SaleManager();  
var showroomManager = new ShowroomManager(); 
var dataManager = new DataManager();


//Загружаем все данные из файла
dataManager.LoadAllData(userManager, showroomManager, saleManager);

bool isLoggedIn = false;
User currentUser = null;

while (!isLoggedIn)
{
    Console.WriteLine("Welcome to Car Showroom Management System!\n1 - Register\n2 - Login\n3 - Exit");
    Console.Write("Choose an option: ");
    
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            userManager.AddUser();
            break;
        case 2:
            currentUser = userManager.Login();
            if (currentUser != null)
            {
                isLoggedIn = true;
            }
            break;
        case 3:
            return;
    }
}

// Инициализация меню для работы с шоурумами, продажами, пользователями и данными
var menuManager = new MenuManager(showroomManager, saleManager, userManager, dataManager);

while (isLoggedIn)
{
    Console.WriteLine($"Welcome, {currentUser.Username}!\n1 - Manage Showrooms\n2 - Manage cars\n3 - Sell cars" +
                      $"\n4 - View sales stats\n5 - Log out");
    Console.Write("Choose an option: ");
    int choice = int.Parse(Console.ReadLine());

    switch (choice)
    {
        case 1:
            menuManager.ShowShowroomMenu();
            break;
        case 2:
            menuManager.ShowCarMenu();
            break;
        case 3:
            menuManager.SellCar();
            break;
        case 4:
            menuManager.ShowSalesStatsMenu();
            break;
        case 5:
            Console.WriteLine("Logging out...");
            dataManager.SaveAllData(userManager, showroomManager, saleManager);
            isLoggedIn = false;
            break;
    }
}
