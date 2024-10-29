namespace BookLib;
public class Book
{
    public string Id {get;set;}=default!;
    public string Title {get;set;}=default!;
    public int Pages {get;set;}=default; 
    public DateTime? Created { get;set;}=default;
    public DateTime? LastUpdated { get;set;}=default;
}
