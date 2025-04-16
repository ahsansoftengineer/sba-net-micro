using System.Linq.Expressions;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Helper;

public static partial class ExtResponse
{
  public static async Task<List<T>> Gets<T>(
    this IQueryable<T> query,
    Expression<Func<T, bool>>? expression,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
    List<string>? Includes)
    where T : class
  {
    return await query.GetsQuery(expression, orderBy, Includes).AsNoTracking().ToListAsync();
  }

  public static async Task<DtoPageRes<T>> ToExtPageRes<T>(
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
  public static async Task<DtoPageRes<T>> ToExtPageReq<T, TDtoSearch>(
    this IQueryable<T> source, DtoPageReq<TDtoSearch?> req)
  {
    var dtoPage = new DtoPage(){
      PageNo = req.PageNo,
      PageSize = req.PageSize,
    };
    return await source.ToExtPageRes(new(dtoPage));
  }

  public static async Task<DtoPageRes<T>> GetsPaginate<T, TDtoSearch>(
      this IQueryable<T> query,
      DtoPageReq<TDtoSearch?> req)
    where TDtoSearch : class
    where T : class, IEntityBeta
  {
    query = query.ToExtQueryFilterSortInclude(req);

    return await query.AsNoTracking().ToExtPageReq(req);
  }
  public static async Task<DtoPageRes<DtoSelect<TKey>>> GetsPaginateOptions<T, TKey, TDtoSearch>(
      this IQueryable<T> query,
      DtoPageReq<TDtoSearch?> req)
    where TDtoSearch : class
    where T : class, IEntityAlpha<TKey>, IEntityBeta, IEntityStatus
  {
    query = query.ToExtQueryFilterSortInclude(req);
 
    var result =  query.ToExtMapSelect<T, TKey>(); // IEntityAlpha, IEntityStatus

    return await result.AsNoTracking().ToExtPageReq(req);
  }
}
