namespace BookLib;

public class BookUpdateReq
{
    public string Id { get; set; } = default!;
    public List<UpdateData> UpdateData { get; set; } = new();
}
