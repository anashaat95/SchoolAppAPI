﻿namespace SchoolApp.Application.Common.Models;

public static class QueryableExtensions
{
    public static async Task<PaginatedResult<T>> ToPaginatedListAsync<T>(this IQueryable<T> soruce, int pageNumber, int pageSize)
        where T : class
    {
        if (soruce == null)
        {
            throw new Exception("Empty");
        }

        pageNumber = pageNumber <= 0 ? 1 : pageNumber;
        pageSize = pageSize == 0 ? 10 : pageSize;
        int count = await soruce.AsNoTracking().CountAsync();

        if (count == 0)
        {
            pageSize = 0;
            return PaginatedResult<T>.Success(new List<T>(), count, pageNumber, pageSize);
        }
        else
        {
            var items = await soruce.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return PaginatedResult<T>.Success(items, count, pageNumber, items.Count >= 10 ? pageSize : items.Count);
        }
    }
}
