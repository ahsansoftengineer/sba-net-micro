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
    List<string>? Include)
    where T : class
  {
    return await query.GetsQuery(expression, orderBy, Include).AsNoTracking().ToListAsync();
  }

  public static async Task<DtoPageRes<T>> ToExtPageRes<T>(
    this IQueryable<T> source, DtoPageResBase<T> DtoPageResBase)
  {
    DtoPageResBase = await source.ToExtQueryPage(DtoPageResBase);
    return new DtoPageRes<T>(DtoPageResBase);
  }

  public static async Task<DtoPageRes<T>> GetsPaginate<T, TDtoSearch>(
      this IQueryable<T> query,
      DtoPageReq<TDtoSearch?> req)
    where TDtoSearch : class
    where T : class, IEntityBeta
  {
    query = query.ToExtQueryFilterSortInclude(req);

    DtoPageResBase<T> DtoPageResBase = new() 
    {
      PageNo = req.PageNo,
      PageSize = req.PageSize
    };

    return await query.AsNoTracking().ToExtPageRes(DtoPageResBase);
  }
  // TODO: NEEDS TO WORK HERE AFTER TESTING
  public static async Task<DtoPageRes<DtoSelect<TKey>>> GetsPaginateOptions<T, TKey, TDtoSearch>(
      this IQueryable<T> query,
      DtoPageReq<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityAlpha<TKey>, IEntityBeta, IEntityStatus
  {
    query = query.ToExtQueryFilterSortInclude(req);
 
    DtoPageResBase<DtoSelect<TKey>> DtoPageResBase = new()
    {
      PageNo = req.PageNo,
      PageSize = req.PageSize,
    };

    var result =  query.ToExtMapSelect<T, TKey>(); // IEntityAlpha, IEntityStatus
   

    return await result.AsNoTracking().ToExtPageRes(DtoPageResBase);
  }
}
