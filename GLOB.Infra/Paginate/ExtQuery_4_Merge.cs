using System.Linq.Expressions;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Helper;

public static partial class ExtQuery
{
  public static IQueryable<T> GetsQuery<T>(
      this IQueryable<T> query,
      Expression<Func<T, bool>>? expression,
      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
      List<string>? Include)
    where T : class
  {
    if (expression != null)
    {
      query = query.Where(expression);
    }

    query = query.ToExtInclues(Include);

    if (orderBy != null)
    {
      query = orderBy(query);
    }
    return query;
  }

  public static IQueryable<T> ToExtQueryFilterSortInclude<T, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityBeta
  {

    query = query.ToExtFilter(req.Filter);
    query = query.ToExtOrderBy(req.Sort); // IEntityBeta

    if (!req.IsMapped)
    {
      query = query.ToExtInclues(req?.Include);
    }

    return query;
  }
  
    public static async Task<(int pageNo, int pageSize, int count, List<T> items)> ToExtQueryPage<T>(this IQueryable<T> source, int pageNo, int pageSize)
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


}
