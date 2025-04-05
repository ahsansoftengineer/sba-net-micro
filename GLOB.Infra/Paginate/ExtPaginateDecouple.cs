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
  public static IQueryable<T> GetsPaginateQuery<T, TDtoSearch>(
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

  public static async Task<BaseDtoPageRes<T>> GetsPaginate<T, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityBeta, IEntityAlpha, IEntityStatus
  {

    query = GetsPaginateQuery(query, req);
    return await query.AsNoTracking()
          .ToExtPaginateAsync(req?.PageNo ?? 1, req?.PageSize ?? 10);

  }

  public static async Task<BaseDtoPageRes<DtoSelect>> GetsPaginateSelect<T, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityAlpha, IEntityBeta, IEntityStatus
  {
    return await query.ToExtMapSelect() // IEntityAlpha, IEntityStatus
    .AsNoTracking().ToExtPaginateAsync(req?.PageNo ?? 1, req?.PageSize ?? 10);
  }
  // Here you Need to Convert to Specific Type

  public static async Task<object> GetsPaginateObj<T, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityBeta, IEntityAlpha, IEntityStatus
  {
    if (!req.IsMapped)
    {
      return await query.GetsPaginate(req);
    }
    else
    {
      return await query.GetsPaginateSelect(req);
    }
  }
}
