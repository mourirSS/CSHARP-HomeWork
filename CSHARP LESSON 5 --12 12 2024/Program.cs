var book = new Book();

while (true)
{
    Console.Write("\nChoose an option: 1 - Add a book, 2 - Delete a book, 3 - Show all books, 4 - exit: ");
    string? option = Console.ReadLine();
    int.TryParse(option, out var choice);

    if (choice == 1)
    {
        Console.Write("\nEnter the title of the book: ");
        string title = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter the author of the book: ");
        string author = Console.ReadLine() ?? string.Empty;

        Console.Write("Enter the year of publication: ");
        string? yearInput = Console.ReadLine();
        int.TryParse(yearInput, out var year);

        book.AddBook(new Book(title, author, year));
    }
    else if (choice == 2)
    {
        Console.Write("\nChoose the index to delete: ");
        string? indexToDelete = Console.ReadLine();
        int.TryParse(indexToDelete, out var indexDelete);
        book.RemoveBook(indexDelete);
    }
    else if (choice == 3)
    {
        Console.WriteLine("Library:");
        book.PrintBooks();
    }
    else if (choice == 4)
    {
        Console.WriteLine("Goodbye!");
        break;
    }
}

class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    
    public Book() {}

    public Book(string title, string author, int year)
    {
        Title = title;
        Author = author;
        Year = year;
    }

    public override string ToString()
    {
        return $"Title: {Title}, Author: {Author}, Year: {Year}";
    }
    
    private List<Book> books = new List<Book>();

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine("Book added!");
    }

    public void RemoveBook(int index)
    {
        if (index >= 0 && index < books.Count)
        {
            books.RemoveAt(index);
            Console.WriteLine("Book removed!");
        }
        else
        {
            Console.WriteLine("Invalid index!");
        }
    }

    public void PrintBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("There are no books");
        }
        else
        {
            for (int i = 0; i < books.Count(); i++)
            {
                Console.WriteLine($"{i}: {books[i]}");
            }
        }
    }
}