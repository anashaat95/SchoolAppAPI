namespace SchoolApp.Application.Common.Models;

public class PaginatedResult<T> where T : class
{
    public List<T> Data { get; set; }
    internal PaginatedResult(bool succeeded, List<T> data = default, int count = 0, int page = 1, int pageSize = 10)
    {
        Data = data;
        CurrentPage = page;
        Succeeded = succeeded;
        PageSize = pageSize;
        TotalPages = count > 0 ? (int)Math.Ceiling(count / (double)pageSize) : 0;
        TotalCount = count;
    }

    public PaginatedResult(List<T> data)
    {
        Data = data;
    }


    public static PaginatedResult<T> Success(List<T> data, int count, int page, int pageSize)
    {
        return new PaginatedResult<T>(true, data, count, page, pageSize);
    }

    public int CurrentPage { get; set; }

    public int TotalPages { get; set; }

    public int TotalCount { get; set; }

    public object Meta { get; set; }

    public int PageSize { get; set; }

    public bool HasPreviousPage => CurrentPage > 1;

    public bool HasNextPage => CurrentPage < TotalPages;

    public List<string> Messages { get; set; } = new();

    public bool Succeeded { get; set; }
}
