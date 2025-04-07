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

    query = query.ToExtQueryInclues(Include);

    if (orderBy != null)
    {
      query = orderBy(query);
    }
    return query;
  }

  public static IQueryable<T> ToExtQueryFilterSortInclude<T, TDtoSearch>(
      this IQueryable<T> query,
      DtoPageReq<TDtoSearch?> req)
    where TDtoSearch : class
    where T : class, IEntityBeta
  {

    query = query.ToExtQueryFilter(req.Filter);
    query = query.ToExtQueryOrderBy(req.Sort); // IEntityBeta
    
    return query.ToExtQueryInclues(req?.Include);
  }
  
  public static async Task<DtoPageRes<T>> ToExtQueryPage<T>(
    this IQueryable<T> source, DtoPageRes<T> p
  )
  {
    if (p.PageNo < 1) p.PageNo = 1;
    if (p.PageSize < 1) p.PageSize = 10;
    if (p.PageSize > 50) p.PageSize = 50;

    p.Count = await source.CountAsync();
    var query = source.Skip((p.PageNo - 1) * p.PageSize)
                .Take(p.PageSize);

    p.Records = await query.ToListAsync();
    return p;
  }


}
