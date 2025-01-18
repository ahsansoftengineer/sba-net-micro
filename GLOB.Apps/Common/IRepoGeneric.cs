using System.Linq.Expressions;

namespace GLOB.Apps.Common;
public interface IRepoGeneric<T>
where T : class
{
  void Save();
  void Update(T entity);
  void Add(T entity);
  void Remove(T entity);
  IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? include = null);
  T? Get(Expression<Func<T, bool>> filter, string? include = null);
  bool Any(Expression<Func<T, bool>>? filter = null);

}