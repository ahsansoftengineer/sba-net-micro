using System.Linq.Expressions;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Helper;

public static partial class ExtRes
{

  public static async Task<List<T>> Gets<T>(
      this IQueryable<T> query,
      Expression<Func<T, bool>>? expression,
      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
      List<string>? Include)
    where T : class
  {
    return await query.GetsQuery(expression, orderBy, Include).AsNoTracking().ToListAsync();
  }

  public static async Task<BaseDtoPageRes<T>> ToExtPageRes<T, TKey>(
    this IQueryable<T> source, int pageNo, int pageSize)
  {
    (pageNo, pageSize, int count, List<T> items) = await source.ToExtQueryPage(pageNo, pageSize);
    return new BaseDtoPageRes<T>(items, count, pageNo, pageSize);
  }

  public static async Task<BaseDtoPageRes<DtoSelect<TKey>>> ToExtPageRes<TKey>(
    this IQueryable<DtoSelect<TKey>> source, int pageNo, int pageSize)
  {
    (pageNo, pageSize, int count, List<DtoSelect<TKey>> items) = await source.ToExtQueryPage(pageNo, pageSize);
    return new BaseDtoPageRes<DtoSelect<TKey>>(items, count, pageNo, pageSize);
  }

  public static async Task<BaseDtoPageRes<T>> GetsPaginate<T, TKey, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class,  IEntityAlpha<TKey>, IEntityBeta,  IEntityStatus
  {

    query = query.ToExtQueryFilterSortInclude(req);
    return await query.AsNoTracking()
          .ToExtPageRes<T, TKey>(req?.PageNo ?? 1, req?.PageSize ?? 10);

  }

  public static async Task<BaseDtoPageRes<DtoSelect<TKey>>> GetsPaginateOptions<T, TKey, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityAlpha<TKey>, IEntityBeta, IEntityStatus
  {
    query = query.ToExtQueryFilterSortInclude(req);

    return query.ToExtMapSelect<T, TKey>() // IEntityAlpha, IEntityStatus
    .AsNoTracking().ToExtPageRes(req?.PageNo ?? 1, req?.PageSize ?? 10);
  }
}
