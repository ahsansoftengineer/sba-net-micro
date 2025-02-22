using GLOB.Domain.Base;
using GLOB.Domain.Common;
using Microsoft.EntityFrameworkCore;

public static class IQueryableExtensions
{
    public static async Task<BaseDtoPageRes<T>> ToPaginateAsync<T>(this IQueryable<T> source, int pageNo = 1, int pageSize = 10)
    {
        if(pageNo < 1) pageNo = 1;
        if(pageSize < 1) pageSize = 10;
        if(pageSize > 50) pageSize = 50;
        
        var count = await source.CountAsync();
        var items = await source.Skip((pageNo - 1) * pageSize)
                                .Take(pageSize)
                                .ToListAsync();
        return new BaseDtoPageRes<T>(items, count, pageNo, pageSize);
    }
}
