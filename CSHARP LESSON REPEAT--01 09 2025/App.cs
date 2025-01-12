using Lesson11;
using Lesson11.Implementations;
using Lesson11.Interfaces;
using System.Text.Json;

namespace Lesson11
{
    public class App
    {
        private readonly Menu _menu;
        private readonly IMovieService _movieService;
        private readonly IFileService _fileService;

        public App(Menu menu, IMovieService movieService, IFileService fileService)
        {
            _menu = menu;
            _movieService = movieService;
            _fileService = fileService;
        }

        public void Start()
        {
            bool flag = true;
            while (flag)
            {
                _menu.DisplayMenu();
                MenuChoice choice = _menu.GetMenuChoice();
                
                switch (choice.Id)
                {
                    case 1:
                        Console.WriteLine($"You chose {choice.Description}");

                        Console.WriteLine("Enter movie name:");
                        var movieName = Console.ReadLine();

                        var res = _movieService.SearchMovie(movieName);

                        if (res.results.Length == 0)
                        {
                            Console.WriteLine("No movies found.");
                        }
                        else
                        {
                            string filePath = @"C:\Users\mourir\Desktop\Lesson11\searchResult.json";          

                            string jsonData = JsonSerializer.Serialize(res.results, new JsonSerializerOptions
                            {
                                WriteIndented = true 
                            });

                            Console.WriteLine("Movies found:");
                            foreach (var movie in res.results)
                            {
                                Console.WriteLine(movie); 
                            }

                            _fileService.Save(filePath, jsonData);

                            Console.WriteLine($"Search results saved to {filePath}.");
                        }

                        break;

                    case 2:
                        Console.WriteLine($"You chose {choice.Description}");

                        Console.WriteLine("Enter the file path to delete:");
                        string filePathToDelete = Console.ReadLine();
                        _fileService.Delete(filePathToDelete);

                        break;

                    case 3:
                        flag = false;
                        Console.WriteLine("Exit");
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
