using GLOB.Domain.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GLOB.Domain.Enums;

namespace GLOB.Infra.Repo;
public interface IRepoGenericz<T>
  where T : class, IEntityAlpha
{
  DbSet<T> GetDBSet();
  bool Any(Expression<Func<T, bool>>? filter = null);
  bool AnyId(int? Id);
  Task<T> Get(Expression<Func<T, bool>> expression, List<string>? Include = null);
  Task<T> Get(int? Id, List<string>? Include = null);


  Task<List<T>> Gets(
    Expression<Func<T, bool>>? expression = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    List<string>? Include = null);
  
  Task Insert(T entity);
  Task InsertRange(IEnumerable<T> entities);
  Task Delete(int? id);
  void DeleteRange(IEnumerable<T> entities);
  void Update(T entity);
  void UpdateStatus(T entity, Status status);

  Task<BaseDtoPageRes<T>> GetsPaginate<TDtoSearch>(PaginateRequestFilter<TDtoSearch?> req)
    where TDtoSearch : class;

  Task<object> GetsPaginateObj<TDtoSearch>(PaginateRequestFilter<TDtoSearch?> req)
    where TDtoSearch : class;

  Task<BaseDtoPageRes<DtoSelect>> GetsPaginateSelect<TDtoSearch>(PaginateRequestFilter<TDtoSearch?> req)
    where TDtoSearch : class;

}