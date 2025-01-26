using GLOB.Domain.Base;
using System.Linq.Expressions;
using X.PagedList;

namespace GLOB.Apps.Common;
public interface IRepoGenericz<T> where T : class
{
  Task<T> Get(
    Expression<Func<T, bool>> expression,
    List<string>? includes = null
  );
  //Task<IPagedList<T>> Gets(BasePagination req, List<string>? includes = null);
  Task<IPagedList<T>> Gets<TDto>(PaginateRequestFilter<T, TDto?> req)
    where TDto : class;

  Task Insert(T entity);
  Task InsertRange(IEnumerable<T> entities);
  Task Delete(int id);
  void DeleteRange(IEnumerable<T> entities);
  void Update(T entity);

  }