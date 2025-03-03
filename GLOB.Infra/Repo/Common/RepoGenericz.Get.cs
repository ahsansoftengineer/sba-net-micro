using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GLOB.Infra.Repo;
public partial class RepoGenericz<T> 
{
  public async Task<T> Get(int? Id, List<string>? Include = null)
  {
    return await this.Get(x => x.Id == Id, Include);
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
    return await query.AsNoTracking().FirstOrDefaultAsync(expression);
  }
}