using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GLOB.Infra.Common;
public partial class RepoGenericz<T> 
{
  public async Task<T> Get(int? Id, List<string>? Include = null)
  {
    var result = await this.Get(x => x.Id == Id, Include);
    return result;
  }
  public async Task<T> Get(
   Expression<Func<T, bool>> expression,
   List<string>? Include = null)
  {
    IQueryable<T> query = _db;
    if (Include != null)
    {
      foreach (var item in Include)
      {
        query = query.Include(item);
      }
    }
    var result = await query.AsNoTracking().FirstOrDefaultAsync(expression);
    return result; //if (result != null) return result; //
  }
}