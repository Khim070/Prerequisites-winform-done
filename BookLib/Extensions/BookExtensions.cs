namespace BookLib;

public static class BookExtensions
{
    public static Book ToEntity(this BookCreateReq req)
    {
        string? id = req.Id?.Trim();
        if (string.IsNullOrEmpty(id))
            id = Guid.NewGuid().ToString();
        return new Book()
        {
            Id = id,
            Title = req.Title,
            Pages = req.Pages,
            Created = DateTime.Now,
            LastUpdated = null
        };
    }
    public static BookResponse ToResponse(this Book book)
    {
        return new BookResponse()
        {
            Id = book.Id,
            Title = book.Title,
            Pages = book.Pages
        };
    }
    public static Book Clone(this Book book)
    {
        return new Book()
        {
            Id = book.Id,
            Title = book.Title,
            Pages = book.Pages,
            Created= book.Created,
            LastUpdated = book.LastUpdated
        };
    }
    public static void Copy(this Book book, Book other)
    {
        book.Id = other.Id;
        book.Title = other.Title;
        book.Pages = other.Pages;
        book.Created = other.Created;
        book.LastUpdated = other.LastUpdated;
    }
    public static void Copy(this Book book, BookUpdateReq req)
    {
        book.Id = req.Id;
        foreach(UpdateData data in req.UpdateData)
        {
            if (string.Equals(data.Field, nameof(Book.Title), StringComparison.OrdinalIgnoreCase))
            {
                book.Title = data.Value?.ToString() ?? "";
                continue;
            }
            if (string.Equals(data.Field, nameof(Book.Pages), StringComparison.OrdinalIgnoreCase))
            {
                if (int.TryParse(data.Value?.ToString() ?? "", out int pages))
                {
                    book.Pages = pages;
                    continue;
                } 
            }
        }
    }
}
