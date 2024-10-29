namespace BookLib;

public class BookRepo 
{
    private readonly FileContext _context;

    public BookRepo(FileContext context)
    {
        _context = context;
    }

    public void Create(Book book)
    {
        _context.Books.Add(book.Clone());
        _context.SaveChanges();
    }
    public void Create(List<Book> books)
    {
        _context.Books.AddRange(books);
        _context.SaveChanges();
    }

    public IQueryable<Book> GetQueryable() => _context.Books.AsQueryable();

    public bool Update(Book book)
    {
        var found = GetQueryable().FirstOrDefault(x => x.Id == book.Id);
        if (found != null)
        {
            found.Copy(book);
            found.LastUpdated = DateTime.Now;
            _context.SaveChanges();
        }
        return found != null;
    }
    public bool Delete(string id)
    {
        var found = _context.Books.Find(x => x.Id == id);
        if (found == null) return false;

        var result = _context.Books.Remove(found);
        _context.SaveChanges();
        return result;
    }
}