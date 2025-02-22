using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GLOB.Infra.Common;
public partial class RepoGenericz<T> 
{
  public async Task<T> Get(int? Id, List<string>? includes = null)
  {
    var result = await this.Get(x => x.Id == Id, includes);
    return result;
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