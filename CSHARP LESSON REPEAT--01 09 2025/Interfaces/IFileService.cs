namespace Lesson11.Interfaces;

public interface IFileService
{
    void Save(string filePath, string content);
    void Delete(string filePath);
}