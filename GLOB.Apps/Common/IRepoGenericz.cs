using GLOB.Domain.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace GLOB.Apps.Common;
public interface IRepoGenericz<T> where T : class
{
  DbSet<T> GetDBSet();
  bool Any(Expression<Func<T, bool>>? filter = null);
  Task<T> Get(Expression<Func<T, bool>> expression, List<string>? includes = null);
  Task<T> Get(int Id, List<string>? includes = null);
  
  
  Task<List<T>> Gets(
    Expression<Func<T, bool>>? expression = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    List<string>? includes = null);
  // Task<IPagedList<T>> Gets(BasePagination req, List<string>? includes = null);
  Task<IPagedList<T>> GetsPaginate<TDto>(PaginateRequestFilter<T, TDto?> req)
    where TDto : class;

  Task Insert(T entity);
  Task InsertRange(IEnumerable<T> entities);
  Task Delete(int id);
  void DeleteRange(IEnumerable<T> entities);
  void Update(T entity);

}