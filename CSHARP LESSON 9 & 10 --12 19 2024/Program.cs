using Calculator;

var operations = new List<ICalculatorOperation>
{
    new Addition(),
    new Subtraction(),
    new Multiplication(),
    new Division()
};

while (true)
{
    Console.WriteLine("Available operations:");
    for (int i = 0; i < operations.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {operations[i].Name}");
    }

    Console.Write("Enter the number of the operation you want to perform or type '9' to quit: ");
    var input = Console.ReadLine();
    
    if (input == "9")
    {
        break;
    }

    if (!int.TryParse(input, out int operationIndex))
    {
        Console.WriteLine("Invalid selection. Please try again");
        continue;
    }
    
    if (operationIndex < 1 || operationIndex > operations.Count)
    {
        Console.WriteLine("Out of range. Please try again");
        continue;
    }

    var selectedOperation = operations[operationIndex - 1];

    try
    {
        Console.Write("Enter the first number: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Enter the second number: ");
        double b = double.Parse(Console.ReadLine());

        double result = selectedOperation.Execute(a, b);
        Console.WriteLine($"Result of {selectedOperation.Name}: {result}");
    }
    catch (DivideByZeroException error)
    {
        Console.WriteLine($"Error: {error.Message}");
    }
    catch (FormatException)
    {
        Console.WriteLine("Error: Invalid input. Please enter numeric values");
    }
}