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

  public static async Task<BaseDtoPageRes<T>> ToExtPageRes<T>(
    this IQueryable<T> source, int pageNo, int pageSize)
  {
    (pageNo, pageSize, int count, List<T> items) = await source.ToExtQueryPage(pageNo, pageSize);
    return new BaseDtoPageRes<T>(items, count, pageNo, pageSize);
  }

  public static async Task<BaseDtoPageRes<DtoSelect>> ToExtPageRes(
    this IQueryable<DtoSelect> source, int pageNo, int pageSize)
  {
    (pageNo, pageSize, int count, List<DtoSelect> items) = await source.ToExtQueryPage(pageNo, pageSize);
    return new BaseDtoPageRes<DtoSelect>(items, count, pageNo, pageSize);
  }

  public static async Task<BaseDtoPageRes<T>> GetsPaginate<T, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityBeta, IEntityAlpha, IEntityStatus
  {

    query = query.ToExtQueryFilterSortInclude(req);
    return await query.AsNoTracking()
          .ToExtPageRes(req?.PageNo ?? 1, req?.PageSize ?? 10);

  }

  public static async Task<BaseDtoPageRes<DtoSelect>> GetsPaginateOptions<T, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityAlpha, IEntityBeta, IEntityStatus
  {
    query = query.ToExtQueryFilterSortInclude(req);

    return await query.ToExtMapSelect() // IEntityAlpha, IEntityStatus
    .AsNoTracking().ToExtPageRes(req?.PageNo ?? 1, req?.PageSize ?? 10);
  }
}
