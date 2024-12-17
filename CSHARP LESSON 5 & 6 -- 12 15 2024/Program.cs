TransportManager manager = new TransportManager();

bool isTrue = true;

while (isTrue)
{
    Console.WriteLine("Menu: \n1 - Add a new transport\n2 - Show all transports\n3 - Start transport\n4 - Remove transport" +
                      "\n5 - Filter transports by type\n6 - Exit");

    Console.Write("Make your choice: ");
    var choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
        {
            string type, brand, model, fuelType;
            int year, maxSpeed;
            
            Console.Write("Input type: Car, Bike, Bus, Truck: ");
            type = Console.ReadLine()!;
            Console.Write("\nInput brand => ");
            brand = Console.ReadLine()!;
            Console.Write("\nInput model => ");
            model = Console.ReadLine()!;
            Console.Write("\nInput fuel type => ");
            fuelType = Console.ReadLine()!;
            Console.Write("\nInput year => ");
            year = Int32.Parse(Console.ReadLine()!);
            Console.Write("\nInput max speed => ");
            maxSpeed = Int32.Parse(Console.ReadLine()!);

            Transport transport;
            switch (type.ToLower())
            {
                case "car":
                    transport = new Car(type, brand, model, year, maxSpeed, fuelType);
                    break;
                case "truck":
                    Console.Write("Input load capacity => ");
                    string loadCapacity = Console.ReadLine()!;
                    transport = new Truck(type, brand, model, year, maxSpeed, loadCapacity);
                    break;
                case "bike":
                    Console.Write("Does it have a sidecar (true/false)? => ");
                    bool hasSidecar = bool.Parse(Console.ReadLine()!);
                    transport = new Bike(type, brand, model, year, maxSpeed, hasSidecar);
                    break;
                case "bus":
                    Console.Write("Input passenger capacity => ");
                    int passengerCapacity = int.Parse(Console.ReadLine()!);
                    transport = new Bus(type, brand, model, year, maxSpeed, passengerCapacity);
                    break;
                default:
                    Console.WriteLine("Invalid transport type.");
                    return;
            }

            manager.AddTransport(transport);
        }
            break; 
        
        case "2": 
        {
            manager.ShowAllTransports();
        }
            break;

        case "3":
        {
            manager.ShowAllTransports();
            Console.WriteLine("Enter the index of transport to start => ");
            if (int.TryParse(Console.ReadLine(), out var index))
            {
                manager.StartTransport(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        } break;

        case "4":
        {
            manager.ShowAllTransports();
            Console.WriteLine("Enter the index of transport to remove => ");
            if (int.TryParse(Console.ReadLine(), out var index))
            {
                manager.RemoveTransport(index - 1);
            }
            else
            {
                Console.WriteLine("Invalid input");
            }
        } break;

        case "5":
        {
            Console.Write("Enter transport type to filter (Car, Bike, Bus, Truck): ");
            var filterType = Console.ReadLine()!;
            manager.FilterTransportsByType(filterType);
        }
            break;

        case "6":
        {
            isTrue = false;
        }
            break;
    }
}


class Transport
{
    public string Type { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public int MaxSpeed { get; set; }

    public Transport() { }

    public Transport(string type, string brand, string model, int year, int maxSpeed)
    {
        Type = type;
        Brand = brand;
        Model = model;
        Year = year;
        MaxSpeed = maxSpeed;
    }
    
    public virtual string ShowInfo()
    {
        return $"Type: {Type}, Brand: {Brand}, Model: {Model}, Year: {Year}, MaxSpeed: {MaxSpeed}";
    }
    public virtual void Move()
    {
        Console.WriteLine("The transport starts moving");
    }
}

class Car : Transport
{
    public string FuelType { get; set; }
    
    public Car() { }

    public Car(string type, string brand, string model, int year, int maxSpeed, string fuelType) 
        : base(type, brand, model, year, maxSpeed)
    {
        FuelType = fuelType;
    }
    public override string ShowInfo()
    {
        return base.ShowInfo() + $", Fuel Type: {FuelType}";
    }

    public override void Move()
    {
        Console.WriteLine($"The car {Brand} {Model} is traveling on the road at speeds up to {MaxSpeed} km/h");
    }
}

class Truck : Transport
{
    public string LoadCapacity { get; set; }
    
    public Truck() { }

    public Truck(string type, string brand, string model, int year, int maxSpeed, string loadCapacity)
        : base(type, brand, model, year, maxSpeed)
    {
        LoadCapacity = loadCapacity;
    }
    
    public override string ShowInfo()
    {
        return base.ShowInfo() + $", Load Capacity: {LoadCapacity} tons";
    }

    public override void Move()
    {
        Console.WriteLine($"The truck {Brand} {Model} moves the cargo");
    }
}

class Bike : Transport
{
    public bool HasSidecar { get; set; }

    public Bike() { }

    public Bike(string type, string brand, string model, int year, int maxSpeed, bool hasSideCar) 
        : base(type, brand, model, year, maxSpeed)
    {
        HasSidecar = hasSideCar;
    }
    
    public override string ShowInfo()
    {
        return base.ShowInfo() + $", Has sidecar: {HasSidecar}";
    }

    public override void Move()
    {
        Console.WriteLine($"The bike {Brand} {Model} rushing down the road.");
    }
}

class Bus : Transport
{
    public int PassangersCapacity { get; set; }
    
    public Bus() { }

    public Bus(string type, string brand, string model, int year, int maxSpeed, int passangersCapacity)
        : base(type, brand, model, year, maxSpeed)
    {
        PassangersCapacity = passangersCapacity;
    }
    
    public override string ShowInfo()
    {
        return base.ShowInfo() + $", Passangers capacity: {PassangersCapacity}";
    }

    public override void Move()
    {
        Console.WriteLine($"The bus {Brand} {Model} carries passengers");
    }
}


class TransportManager
{
    List<Transport> transports = new List<Transport>();

    public void AddTransport(Transport transport)
    {
        transports.Add(transport);
        Console.WriteLine("Transport added successfully.");
    }

    public void ShowAllTransports()
    {
        if (transports.Count == 0)
        {
            Console.WriteLine("No transports are available.");
            return;
        }

        Console.WriteLine("List of all transports:");
        for (int i = 0; i < transports.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {transports[i].ShowInfo()}");
        }
    }

    public void StartTransport(int index)
    {
        if (index < 0 || index >= transports.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }
        
        transports[index].Move();
    }

    public void RemoveTransport(int index)
    {
        if (index < 0 || index >= transports.Count)
        {
            Console.WriteLine("Invalid index.");
            return;
        }

        transports.RemoveAt(index);
        Console.WriteLine("Transport removed successfully.");
    }
    
    public void FilterTransportsByType(string type)
    {
        var filteredTransports = transports.Where(t =>
            t.GetType().Name.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();

        if (filteredTransports.Count == 0)
        {
            Console.WriteLine($"No transports of type {type} found.");
            return;
        }

        Console.WriteLine($"List of all transports of type {type}:");
        for (int i = 0; i < filteredTransports.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {filteredTransports[i].ShowInfo()}");
        }
    }

}    