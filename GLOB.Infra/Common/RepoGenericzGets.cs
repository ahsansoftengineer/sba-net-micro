using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.PagedList;

namespace GLOB.Infra.Common;
public partial class RepoGenericz<T> 
{
  // Filter, OrderBy, Include
  public async Task<List<T>> Gets(
    Expression<Func<T, bool>>? expression = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    List<string>? includes = null)
  {
    IQueryable<T> query = _db;
    if (expression != null)
    {
      query = query.Where(expression);
    }

    if (includes != null)
    {
      foreach (var item in includes)
      {
        query = query.Include(item);
      }
    }

    if (orderBy != null)
    {
      query = orderBy(query);
    }
    return await query.AsNoTracking().ToListAsync();
  }

  // Filter, OrderBy, Include, Pagination
  public async Task<IPagedList<T>> GetsPaginate<TDto>(
    PaginateRequestFilter<T, TDto>? req
  )
    where TDto : class
  {
    if (req == null)
    {
      req = new PaginateRequestFilter<T, TDto>()
      {
        PageNo = 1,
        PageSize = 10,
        Sort = null,
        Search = null
      };
    }

    IQueryable<T> query = _db;
    //query = query.FilterByGeneric<T, TDto>(req.Search);
    //query = query.OrderByGeneric<T>(req.Sort);
    // Simplified Form
    query = query.FilterByGeneric(req.Search);
    query = query.OrderByGeneric(req.Sort);
    query = query.IncluesByGeneric(req.includes);
    return null;
    // return await query
    //   .AsNoTracking()
    //   .ToListAsync()
    //   .ToPagedListAsync(req.PageNo, req.PageSize);
  }
}