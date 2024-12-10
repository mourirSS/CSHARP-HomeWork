var autoPark = new AutoPark();

autoPark.AddVehicle(new Car("BMW", "X5", 50000m, 260, 2.5f, BodyType.Suv, FuelType.Petrol));
autoPark.AddVehicle(new Car("Honda", "Accord", 40000m, 240, 2.3f, BodyType.Sedan, FuelType.Petrol));
autoPark.AddVehicle(new Bus("Mercedes", "Sprinter", 75000m, 180, 5.0f, 20));
Console.WriteLine("AutoPark:");
autoPark.DisplayAutoPark();

Console.Write("\nChoose the index to delete: ");
string? indexToDelete = Console.ReadLine();
int.TryParse(indexToDelete, out var indexDelete);
autoPark.DeleteVehicle(indexDelete);
Console.WriteLine("\nAutoPark after deletion:");
autoPark.DisplayAutoPark();

Console.Write("\nChoose the index to edit: ");
string? indexToEdit = Console.ReadLine();
int.TryParse(indexToEdit, out var indexEdit);

if (indexEdit >= 0 && indexEdit < autoPark.GetVehicleCount())
{
    var currentVehicle = autoPark.GetVehicle(indexEdit);
    if (currentVehicle is Car)
    {
        var updatedCar = AutoPark.InputCarDetails();
        autoPark.EditVehicle(indexEdit, updatedCar);
    }
    else if (currentVehicle is Bus)
    {
        var updatedBus = AutoPark.InputBusDetails();
        autoPark.EditVehicle(indexEdit, updatedBus);
    }
    else
    {
        Console.WriteLine("Unknown transport type");
    }
}
else
{
    Console.WriteLine("Invalid index");
}

Console.WriteLine("\nAutoPark after editing:");
autoPark.DisplayAutoPark();


enum FuelType
{
    Petrol,
    Diesel,
    Electric,
    Hybrid
}

enum BodyType
{
    Sedan,
    Suv,
    Hatchback,
    Coupe,
    Minivan,
    Bus
}

abstract class Transport
{
    public string Brand { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int TopSpeed { get; set; }
    public float Weight { get; set; }

    public Transport() { }

    public Transport(string brand, string model, decimal price, int topSpeed, float weight)
    {
        Brand = brand;
        Model = model;
        Price = price;
        TopSpeed = topSpeed;
        Weight = weight;
    }

    public override string ToString()
    {
        return $"Brand: {Brand}, Model: {Model}, Price: {Price}$, Top speed: {TopSpeed} km/h, Weight: {Weight} kg";
    }
}

class Car : Transport
{
    public BodyType BodyType { get; set; }
    public FuelType FuelType { get; set; }

    public Car() { }

    public Car(string brand, string model, decimal price, int topSpeed, float weight, BodyType bodyType, FuelType fuelType)
        : base(brand, model, price, topSpeed, weight)
    {
        BodyType = bodyType;
        FuelType = fuelType;
    }

    public override string ToString()
    {
        return base.ToString() + $"Body Type: {BodyType} | Fuel Type: {FuelType}";
    }
}

class Bus : Transport
{
    public int PassengerCap { get; set; }

    public Bus() { }

    public Bus(string brand, string model, decimal price, int topSpeed, float weight, int passengerCap)
        : base(brand, model, price, topSpeed, weight)
    {
        PassengerCap = passengerCap;
    }

    public override string ToString()
    {
        return base.ToString() + $", Passenger Capacity: {PassengerCap}";
    }
}

class AutoPark
{
    private List<Transport> transports = new List<Transport>();

    public void AddVehicle(Transport transport)
    {
        transports.Add(transport);
    }

    public void DeleteVehicle(int index)
    {
        if (index >= 0 && index < transports.Count)
        {
            transports.RemoveAt(index);
        }
        else
        {
            Console.WriteLine("Invalid index");
        }
    }

    public void EditVehicle(int index, Transport newVehicle)
    {
        if (index >= 0 && index < transports.Count)
        {
            transports[index] = newVehicle;
        }
        else
        {
            Console.WriteLine("Invalid index");
        }
    }

    public void DisplayAutoPark()
    {
        if (transports.Count == 0)
        {
            Console.WriteLine("The auto park is empty.");
        }
        else
        {
            for (int i = 0; i < transports.Count; i++)
            {
                Console.WriteLine($"{i}: {transports[i]}");
            }
        }

    }

    public static Car InputCarDetails()
    {
        Console.WriteLine("\nEnter details about the car:");
        Console.Write("Brand: ");
        string brand = Console.ReadLine() ?? string.Empty;

        Console.Write("Model: ");
        string model = Console.ReadLine() ?? string.Empty;

        Console.Write("Price: ");
        decimal.TryParse(Console.ReadLine(), out var price);

        Console.Write("Top Speed: ");
        int.TryParse(Console.ReadLine(), out var topSpeed);

        Console.Write("Weight: ");
        float.TryParse(Console.ReadLine(), out var weight);

        Console.Write("Body Type (0-Sedan, 1-Suv, 2-Hatchback, 3-Coupe, 4-Minivan, 5-Bus): ");
        Enum.TryParse(Console.ReadLine(), out BodyType bodyType);

        Console.Write("Fuel Type (0-Petrol, 1-Diesel, 2-Electric, 3-Hybrid): ");
        Enum.TryParse(Console.ReadLine(), out FuelType fuelType);

        return new Car(brand, model, price, topSpeed, weight, bodyType, fuelType);
    }

    public static Bus InputBusDetails()
    {
        Console.WriteLine("\nEnter details for the bus:");
        Console.Write("Brand: ");
        string brand = Console.ReadLine() ?? string.Empty;

        Console.Write("Model: ");
        string model = Console.ReadLine() ?? string.Empty;

        Console.Write("Price: ");
        decimal.TryParse(Console.ReadLine(), out decimal price);

        Console.Write("Top Speed: ");
        int.TryParse(Console.ReadLine(), out int topSpeed);

        Console.Write("Weight: ");
        float.TryParse(Console.ReadLine(), out float weight);

        Console.Write("Passenger Capacity: ");
        int.TryParse(Console.ReadLine(), out int passengerCap);

        return new Bus(brand, model, price, topSpeed, weight, passengerCap);
    }

    public int GetVehicleCount()
    {
        return transports.Count;
    }

    public Transport GetVehicle(int index)
    {
        return transports[index];
    }
}
