namespace BookLib;

public class BookCreateReq
{
    public string? Id { get; set; } = default;
    public string Title { get; set; } = default!;
    public int Pages { get; set; } = default;
}
