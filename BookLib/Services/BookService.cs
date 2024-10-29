using RestClientLib;
using System.Net;
namespace BookLib;

public class BookService 
{
    private static readonly List<BookCreateReq> reqs =
        new(){
            new()
            {
                Title = "Mastering Java",
                Pages = 200
            },
            new()
            {
                Title = "Learning C# 12.0",
                Pages = 400
            },
            new()
            {
                Title = "Introduction to Programming Language",
                Pages = 100
            }
        };

    public static List<BookCreateReq> InitRequest => reqs;

    private readonly BookRepo _repo;
    public BookService(BookRepo repo)
    {
        _repo = repo;
    }

    public List<string> Initialize()
    {
        if (!_repo.GetQueryable().Any())
        {
            var books = reqs.Select(req => req.ToEntity()).ToList();
            _repo.Create(books);
            return books.Select(x => x.Id).ToList()??new();
        }
        return new();
    }

    public Result<bool> Exist(string id)
    {
        var result = _repo.GetQueryable().Any(x => x.Id == id);
        return Result<bool>.Success(result, HttpStatusCode.Found);
    }
    public Result<string?> Create(BookCreateReq req)
    {
        var book = req.ToEntity();
        if (Exist(book.Id).Data == true) 
            return Result<string?>.Fail(HttpStatusCode.Found, $"The Book with the id, {book.Id}, does already exist");
        _repo.Create(book);
        return Result<string?>.Success(book.Id, HttpStatusCode.Created, "Successfully created");
    }
    
    public Result<List<BookResponse>> ReadAll()
    {
        var result= _repo.GetQueryable().Select(x=>x.ToResponse()).ToList();
        return Result<List<BookResponse>>.Success(result);
    }
    public Result<BookResponse?> Read(string id)
    {
        var entity = _repo.GetQueryable().FirstOrDefault(x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
        var response= entity?.ToResponse();
        return Result<BookResponse?>.Success(response);
    }
   
    public Result<string?> Update(BookUpdateReq req)
    {
        var found = _repo.GetQueryable().FirstOrDefault(x => x.Id == req.Id);
        if (found == null) return Result<string?>.Fail( HttpStatusCode.NotFound, $"No book with id, {req.Id}");
        var book = found.Clone();
        book.Copy(req);
        var result= _repo.Update(book);
        return result == true ? Result<string?>.Success(book.Id, HttpStatusCode.NoContent, "Successfully updated")
                : Result<string?>.Fail( HttpStatusCode.NotFound, $"Failed to update book with id, {book.Id}");
    }
   
    public Result<string?> Delete(string id)
    {
        var found = _repo.GetQueryable().FirstOrDefault(x => x.Id == id);
        if (found == null) 
            return Result<string?>.Fail( HttpStatusCode.NotFound, $"No book with id, {id}");
        var result= _repo.Delete(found.Id);
        return result == true ? Result<string?>.Success(found.Id, HttpStatusCode.NoContent, "Successfully deleted")
                : Result<string?>.Fail(HttpStatusCode.Forbidden, $"Failed to delete Book with id, {id}");
    }
}
