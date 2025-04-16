using System.Linq.Expressions;
using GLOB.Domain.Base;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Paginate;

public static partial class ExtResponse
{
  public static async Task<List<T>> ToExtList<T>(
    this IQueryable<T> query,
    Expression<Func<T, bool>>? expression,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
    List<string>? Includes)
    where T : class
  {
    return await query.ToExtQuery_Query(expression, orderBy, Includes).AsNoTracking().ToListAsync();
  }
  public static async Task<VMPaginate<T>> ToExtPageReq<T, TDtoSearch>(
    this IQueryable<T> source, DtoRequestPageOption<TDtoSearch?> req)
  {
    var dtoPage = new DtoPage(){
      PageNo = req.PageNo,
      PageSize = req.PageSize,
    };
    return await source.ToExtVMPage(new(dtoPage));
  }

  public static async Task<VMPaginate<T>> ToExtVMPageNoTrack<T, TDtoSearch>(
      this IQueryable<T> query,
      DtoRequestPage<TDtoSearch?> req)
    where TDtoSearch : class, IDtoSearch
    where T : class, IEntityBeta
  {
    query = query.ToExtQueryFilter(req.Filter);
    query = query.ToExtQueryOrderBy(req.Sort); // IEntityBeta
    query = query.ToExtQueryInclues(req?.Include);

    return await query.AsNoTracking().ToExtPageReq(req);
  }
  
  public static async Task<VMPaginate<DtoSelect<TKey>>> ToExtVMPageOptionsNoTrack<T, TKey, TDtoSearch>(
      this IQueryable<T> query,
      DtoRequestPageOption<TDtoSearch?> req)
    where TDtoSearch : class, IDtoSearch
    where T : class, IEntityAlpha<TKey>, IEntityBeta, IEntityStatus
  {
    query = query.ToExtQueryFilter(req.Filter);
    query = query.ToExtQueryOrderBy(req.Sort);
 
    var result =  query.ToExtMapSelect<T, TKey>(); // IEntityAlpha, IEntityStatus

    return await result.AsNoTracking().ToExtPageReq(req);
  }
}
