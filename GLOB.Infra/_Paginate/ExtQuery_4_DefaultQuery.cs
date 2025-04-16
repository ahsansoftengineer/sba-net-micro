using System.Linq.Expressions;
using GLOB.Domain.Base;

namespace GLOB.Infra.Paginate;

public static partial class ExtQuery
{
  public static IQueryable<T> ToExtQuery_Query<T>(
      this IQueryable<T> query,
      Expression<Func<T, bool>>? expression,
      Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
      List<string>? Include)
    where T : class
  {
    if (expression != null)
    {
      query = query.Where(expression);
    }

    query = query.ToExtQueryInclues(Include);

    if (orderBy != null)
    {
      query = orderBy(query);
    }
    return query;
  }

  public static IQueryable<T> ToExtQueryFilterSortInclude<T, TDtoSearch>(
      this IQueryable<T> query,
      DtoRequestPage<TDtoSearch?> req)
    where TDtoSearch : class
    where T : class, IEntityBeta
  {

    query = query.ToExtQueryFilter(req.Filter);
    query = query.ToExtQueryOrderBy(req.Sort); // IEntityBeta
    
    return query.ToExtQueryInclues(req?.Include);
  }
}
