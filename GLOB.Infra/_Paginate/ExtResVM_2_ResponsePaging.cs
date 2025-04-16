using System.Linq.Expressions;
using System.Net;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Http.HttpResults;
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

  public static async Task<DtoPageRes<T>> ToExtPageRes<T, TDtoSearch>(
    this IQueryable<T> source, DtoPageReq<TDtoSearch?> req)
  {
    var dtoPage = new DtoPage(){
      PageNo = req.PageNo,
      PageSize = req.PageSize,
    };
    return await source.ToExtQueryPage(new(dtoPage));
  }

  public static async Task<DtoPageRes<T>> GetsPaginate<T, TDtoSearch>(
      this IQueryable<T> query,
      DtoPageReq<TDtoSearch?> req)
    where TDtoSearch : class
    where T : class, IEntityBeta
  {
    query = query.ToExtQueryFilterSortInclude(req);

    return await query.AsNoTracking().ToExtPageRes(req);
  }
  public static async Task<DtoPageRes<DtoSelect<TKey>>> GetsPaginateOptions<T, TKey, TDtoSearch>(
      this IQueryable<T> query,
      DtoPageReq<TDtoSearch?> req)
    where TDtoSearch : class
    where T : class, IEntityAlpha<TKey>, IEntityBeta, IEntityStatus
  {
    query = query.ToExtQueryFilterSortInclude(req);
 
    var result =  query.ToExtMapSelect<T, TKey>(); // IEntityAlpha, IEntityStatus

    return await result.AsNoTracking().ToExtPageRes(req);
  }
}
