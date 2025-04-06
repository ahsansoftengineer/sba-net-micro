using System.Linq.Expressions;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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

  public static async Task<BaseDtoPageRes<T>> ToExtPageRes<T>(
    this IQueryable<T> source, BaseDtoPageResConstruct<T> p)
  {
    p = await source.ToExtQueryPage(p);
    return new BaseDtoPageRes<T>(p);
  }

  public static async Task<BaseDtoPageRes<T>> GetsPaginate<T, TDtoSearch>(
      this IQueryable<T> query,
      PaginateRequestFilter<TDtoSearch>? req)
    where TDtoSearch : class
    where T : class, IEntityBeta
  {
    BaseDtoPageResConstruct<T> p = new() 
    {
      PageNo = req.PageNo,
      PageSize = req.PageSize
    };
    query = query.ToExtQueryFilterSortInclude(req);
    return await query.AsNoTracking().ToExtPageRes(p);

  }

  // public static async Task<BaseDtoPageRes<DtoSelect<TKey>>> GetsPaginateOptions<T, TKey, TDtoSearch>(
  //     this IQueryable<T> query,
  //     PaginateRequestFilter<TDtoSearch>? req)
  //   where TDtoSearch : class
  //   where T : class, IEntityAlpha<TKey>, IEntityBeta, IEntityStatus
  // {
  //   BaseDtoPageResConstruct<DtoSelect<Key>> p = new() 
  //   {
  //     PageNo = req.PageNo,
  //     PageSize = req.PageSize
  //   };
  //   query = query.ToExtQueryFilterSortInclude(req);

  //   var result =  query.ToExtMapSelect<T, TKey>(); // IEntityAlpha, IEntityStatus
  //   return await result.AsNoTracking().ToExtPageRes(p);
  // }
}
