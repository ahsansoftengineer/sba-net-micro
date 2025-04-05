using System.Linq.Expressions;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Helper;
public static partial class RepoExtensionActions
{
  public static async Task<List<T>> Gets<T>(
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
    return await query.AsNoTracking().ToListAsync();
  }
  public static async Task<object> GetsPaginate<T, TDtoSearch>(
      this IQueryable<T> query, 
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityAlpha, IEntityBeta, IEntityStatus
  {

    query = query.ToExtFilter(req.Filter);
    query = query.ToExtOrderBy(req.Sort); // IEntityBeta

    if (!req.IsMapped)
    {
      query = query.ToExtInclues(req?.Include);
      return await query.AsNoTracking()
        .ToExtPaginateAsync(req?.PageNo ?? 1, req?.PageSize ?? 10);
    }
    else
    {
      return await query.ToExtMapping() // IEntityAlpha, IEntityStatus
      .AsNoTracking().ToExtPaginateAsync(req?.PageNo ?? 1, req?.PageSize ?? 10);
    }
  }

    public static async Task<object> GetsPaginateStrg<T, TDtoSearch>(
      this IQueryable<T> query, 
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityAlphaStrg, IEntityBeta, IEntityStatus
  {

    query = query.ToExtFilter(req.Filter);
    query = query.ToExtOrderBy(req.Sort); // IEntityBeta

    if (!req.IsMapped)
    {
      query = query.ToExtInclues(req?.Include);
      return await query.AsNoTracking()
        .ToExtPaginateAsync(req?.PageNo ?? 1, req?.PageSize ?? 10);
    }
    else
    {
      return await query.ToExtMappingStrg() // IEntityAlpha, IEntityStatus
      .AsNoTracking().ToExtPaginateAsync(req?.PageNo ?? 1, req?.PageSize ?? 10);
    }
  }
}
