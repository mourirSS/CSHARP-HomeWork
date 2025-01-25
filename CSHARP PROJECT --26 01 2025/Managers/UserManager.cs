namespace ConsoleApp1.Managers;
using ConsoleApp1.Models;

class UserManager
{
    public List<User> Users { get; set; } = new();
    
    //Регистрация нового пользователя
    public void AddUser()
    {
        Console.Write("Write username: ");
        string username = Console.ReadLine();

        Console.Write("Write password: ");
        string password = Console.ReadLine();

        var user = new User
        {
            Username = username,
            Password = password
        };
        
        Users.Add(user);
        Console.WriteLine($"User {username} added successfully!");
    }
    
    //Логин пользователя
    public User Login()
    {
        Console.Write("Enter username: ");
        string username = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        
        var user = Users.Find(u => u.Username == username && u.Password == password);

        if (user != null)
        {
            Console.WriteLine($"User {username} logged in!");
            return user;
        }
        else
        {
            Console.WriteLine("User not found!");
            return null;
        }
    }
}