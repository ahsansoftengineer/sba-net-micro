using System.Linq.Expressions;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Helper;

public static partial class RepoExtensionActions
{
  public static async Task<(int pageNo, int pageSize, int count, List<T> items)> ToExtPaginateQuery<T>(IQueryable<T> source, int pageNo, int pageSize)
  {
    if (pageNo < 1) pageNo = 1;
    if (pageSize < 1) pageSize = 10;
    if (pageSize > 50) pageSize = 50;

    var count = await source.CountAsync();
    var query = source.Skip((pageNo - 1) * pageSize)
                .Take(pageSize);

    var items = await query.ToListAsync();
    return (pageNo, pageSize, count, items);
  }

  public static async Task<BaseDtoPageRes<T>> ToExtPaginateAsync<T>(this IQueryable<T> source, int pageNo = 1, int pageSize = 10)
  {
    (pageNo, pageSize, int count, List<T> items) = await ToExtPaginateQuery(source, pageNo, pageSize);
    return new BaseDtoPageRes<T>(items, count, pageNo, pageSize);
  }

  public static async Task<BaseDtoPageRes<DtoSelect>> ToExtPaginateAsync(this IQueryable<DtoSelect> source, int pageNo = 1, int pageSize = 10)
  {
    (pageNo, pageSize, int count, List<DtoSelect> items) = await ToExtPaginateQuery(source, pageNo, pageSize);
    return new BaseDtoPageRes<DtoSelect>(items, count, pageNo, pageSize);
  }


}
