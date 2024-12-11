//task1
// Console.Write("The number must be in the range from 0 to 100. Your input here => ");
//
// string? input = Console.ReadLine();
//
// int.TryParse(input, out var num);
//
// Console.WriteLine($"Your input is {num}");
//
// bool success = true;
//
// if (num > 100 || num < 0)
// {
//     success = false;
//     Console.WriteLine("The number must be between 0 and 100");
// }
//
// while (success)
// {
//     if (num % 3 == 0 && num % 5 == 0)
//     {
//         Console.WriteLine("FizzBuzz");
//     }
//     else if (num % 3 == 0)
//     {
//         Console.WriteLine("Fizz");
//     }
//     else if (num % 5 == 0)
//     { 
//         Console.WriteLine("Buzz");
//     }
//     else if (num % 3 != 0 && num % 5 != 0)
//     {
//         Console.WriteLine(num);
//     } 
//     break;
// }


//task2
// Console.Write("num1 = ");
// string? num1 = Console.ReadLine();
// int.TryParse(num1, out var number1);
//
// Console.Write("percent = ");
// string? num2 = Console.ReadLine();
// int.TryParse(num2, out var percent);
//
// Console.WriteLine($"Number = {number1}, percent = {percent}%");
//
// int num3 = (number1 * percent) / 100;
//
// Console.WriteLine($"The {percent}% of {number1} is {num3}");


//task3
// Console.Write("num1 = ");
// string? num1 = Console.ReadLine();
// int.TryParse(num1, out var number1);
//
// Console.Write("num2 = ");
// string? num2 = Console.ReadLine();
// int.TryParse(num2, out var number2);
//
// Console.Write("num3 = ");
// string? num3 = Console.ReadLine();
// int.TryParse(num3, out var number3);
//
// Console.Write("num4 = ");
// string? num4 = Console.ReadLine();
// int.TryParse(num4, out var number4);
//
// Console.WriteLine($"{number1}{number2}{number3}{number4}");


//task5
// var date = new DateTime(2021, 12, 22);
// string season = "winter";
//
// if (date.Month >= 3 && date.Month <= 5)
// {
//     season = "spring";
// }
// else if (date.Month >= 6 && date.Month <= 8)
// {
//     season = "summer";
// }
// else if (date.Month >= 9 && date.Month <= 11)
// {
//     season = "autumn";
// }
//
// Console.WriteLine($"{season} - {date.DayOfWeek}");


//task6
// Console.WriteLine("1 - Fahrenheit to Celsius, 2 - Celsius to Fahrenheit");
// Console.Write("Make a choice (1 or 2) : ");
// string? temperature = Console.ReadLine();
//
// if (temperature == "1")
// {
//     Console.Write("Write temperature: ");
//     string? num = Console.ReadLine();
//     int.TryParse(num, out var number);
//     
//     int celsius = (number - 32) * 5 / 9;
//
//     Console.WriteLine($"{number} Fahrenheits are {celsius} Celsius");
// }
// else if (temperature == "2")
// {
//     Console.Write("Write temperature: ");
//     string? num = Console.ReadLine();
//     int.TryParse(num, out var number);
//     
//     int fahrenheits = number * 9 / 5 + 32;
//
//     Console.WriteLine($"{number} Celsius are {fahrenheits} Fahrenheits");
// }


// //task7
Console.Write("Write the first number: ");
string? num1 = Console.ReadLine();
int.TryParse(num1, out var number1);

Console.Write("Write the second number: ");
string? num2 = Console.ReadLine();
int.TryParse(num2, out var number2);

if (number1 > number2)
{
    int temp = number1;
    number1 = number2;
    number2 = temp;
}

Console.WriteLine($"Even numbers in the range from {number1} to {number2}: ");

for (int i = number1; i <= number2; i++)
{
    if (i % 2 == 0)
    {
        Console.Write($"{i} ");
    }
}
