//task1
// int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
//
// int evenCount = array.Count(x => x % 2 == 0);
// int oddCount = array.Count(x => x % 2 != 0);
//
// Console.WriteLine($"Even count: {evenCount}");
// Console.WriteLine($"Odd count: {oddCount}");


//task2
// int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
//
// Console.Write("Write the number: ");
// string? num1 = Console.ReadLine();
// int.TryParse(num1, out var number1);
//
// int count = array.Count(x => x < number1);
//
// Console.WriteLine(count);


//task4
// int[] array1 = { 1, 2, 3, 4, 5 };
// int[] array2 = { 1, 4, 8, 9, 10 };
//
// int count = 0;
//
// for (int i = 0; i < array1.Length; i++)
// {
//     for (int j = 0; j < array2.Length; j++)
//     {
//         if (array1[i] == array2[j])
//         {
//             count++;
//         }
//     }
// }
//
// int[] array3 = new int[count];
// int index = 0;
//
// for (int i = 0; i < array1.Length; i++)
// {
//     for (int j = 0; j < array2.Length; j++)
//     {
//         if (array1[i] == array2[j])
//         {
//             array3[index] = array1[i];
//             index++;
//         }
//     }
// }
//
// for (int i = 0; i < array3.Length; i++)
// {
//     Console.WriteLine(array3[i]);
// }

//task5
// int[,] array = {
//     { 3, 5, 7 },
//     { 2, 8, 6 },
//     { 1, 4, 9 }
// };
//
// int min = array[0, 0];
// int max = array[0, 0];
//
// for (int i = 0; i < 3; i++)
// {
//     for (int j = 0; j < 3; j++)
//     {
//         if (array[i, j] < min)
//         {
//             min = array[i, j];
//         }
//
//         if (array[i, j] > max)
//         {
//             max = array[i, j];
//         }
//     }
// }
//
// Console.WriteLine($"Minimum: {min}, Maximum: {max}");


//task6
// Console.Write("Write the sentence: ");
// string? sentence = Console.ReadLine();
//
// int count = 0;
//
// foreach (char i in sentence)
// {
//     if (i == ' ')
//     {
//         count++;
//     }
// }
//
// Console.WriteLine(count += 1);


//task7
// Console.Write("Write your sentence: ");
// string? sentence = Console.ReadLine();
//
// string[] words = sentence.Split(' ');
//
// for (int i = 0; i < words.Length; i++)
// {
//     char[] charArray = words[i].ToCharArray();
//     Array.Reverse(charArray);
//     words[i] = new string(charArray);
// }
//
// string result = string.Join(" ", words);
//
// Console.WriteLine($"Result: {result}");


//task8
// Console.Write("Write the sentence: ");
// string? sentence = Console.ReadLine();
//
// int count = 0;
//
// foreach (char i in sentence)
// {
//     if (i == 'a' || i == 'A' || i == 'i' || i == 'I' || i == 'e' || i == 'E' ||
//         i == 'u' || i == 'U' || i =='o' || i == 'O' )
//     {
//         count++;
//     }
// }
//
// Console.WriteLine(count);


//task9
Console.Write("Write the sentence: ");
string? sentence = Console.ReadLine();

Console.Write("Write the word to search: ");
string? search = Console.ReadLine();

if (sentence != null && search != null)
{
    string[] words = sentence.Split(' ');
    bool found = false;

    foreach (string word in words)
    {
        if (word == search)
        {
            Console.WriteLine($"Found the word: {word}");
            found = true;
        }
    }
    
    if (!found)
    {
        Console.WriteLine("No word found");      
    }
}
