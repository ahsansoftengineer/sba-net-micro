using GLOB.Domain.Base;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GLOB.Domain.Enums;

namespace GLOB.Infra.Repo;

public interface IRepoGenericz<T> : IRepoGenericz<T, int> 
  where T : class, IEntityAlpha<int>
{

}
public interface IRepoGenericz<T, TKey>
  where T : class, IEntityAlpha<TKey>
{
  DbSet<T> GetDBSet();
  bool Any(Expression<Func<T, bool>>? filter = null);
  bool AnyId(TKey? Id);
  Task<T> Get(Expression<Func<T, bool>> expression, List<string>? Includes = null);
  Task<T> Get(TKey Id, List<string>? Includes = null);

  Task<List<T>> GetsByIds(List<TKey>? Ids = null, List<string>? Includes = null);
  Task<List<T>> Gets(
    Expression<Func<T, bool>>? expression = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    List<string>? Include = null);
  
  Task<T> Insert(T entity);
  Task InsertRange(IEnumerable<T> entities);
  Task Delete(TKey Id);
  void DeleteRange(IEnumerable<T> entities);
  void Update(T entity);
  void UpdateStatus(T entity, Status status);

  Task<VMPaginate<T>> GetsPaginate<TDtoSearch>(DtoRequestPage<TDtoSearch?> req)
    where TDtoSearch : class;

  Task<VMPaginate<DtoSelect<TKey>>> GetsPaginateOptions<TDtoSearch>(DtoRequestPage<TDtoSearch?> req)
    where TDtoSearch : class;
}