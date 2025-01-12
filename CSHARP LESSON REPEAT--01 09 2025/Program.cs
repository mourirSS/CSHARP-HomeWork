using Lesson11;
using Lesson11.Implementations;
using Lesson11.Interfaces;

Menu menu = new();
IMovieService movieService = new MovieService();
IFileService fileService = new FileService();

App app = new(menu, movieService, fileService);
app.Start();