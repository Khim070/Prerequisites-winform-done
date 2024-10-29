using System.Text.Json;

namespace BookLib;

public class FileContext
{
    private readonly string _filename;

    public FileContext(string filename)
    {
        _filename = filename;
        if (!File.Exists(_filename))
        {
            File.WriteAllText(_filename, "[]");
        }
        string jsonData = File.ReadAllText(_filename) ?? "[]";
        Books = JsonSerializer.Deserialize<List<Book>>(jsonData) ?? new();
    }
    public List<Book> Books { get; set; }
    public int SaveChanges()
    {
        File.WriteAllText(_filename, JsonSerializer.Serialize<List<Book>>(Books));
        return Books.Count;
    }
}
