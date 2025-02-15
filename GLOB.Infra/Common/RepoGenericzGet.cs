using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.PagedList;

namespace GLOB.Infra.Common;
public partial class RepoGenericz<T> 
{
  public async Task<T> Get(
   int Id,
   List<string>? includes = null)
  {
    IQueryable<T> query = _db;
    if (includes != null)
    {
      foreach (var item in includes)
      {
        query = query.Include(item);
      }
    }
    var result = await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id); 
    return result; //if (result != null) return result; //
  }
  public async Task<T> Get(
   Expression<Func<T, bool>> expression,
   List<string>? includes = null)
  {
    IQueryable<T> query = _db;
    if (includes != null)
    {
      foreach (var item in includes)
      {
        query = query.Include(item);
      }
    }
    var result = await query.AsNoTracking().FirstOrDefaultAsync(expression);
    return result; //if (result != null) return result; //
  }
}