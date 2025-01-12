using Lesson11.Interfaces;

namespace Lesson11.Implementations;

public class FileService : IFileService
{
    public void Save(string filePath, string content)
    {
        File.WriteAllText(filePath, content); 
    }

    public void Delete(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine($"File {filePath} deleted successfully");
        }
        else
        {
            Console.WriteLine($"File {filePath} does not exist");
        }
    }
}