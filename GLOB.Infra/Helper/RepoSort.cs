using System.Linq.Dynamic.Core;
using GLOB.Domain.Base;

namespace GLOB.Infra.Helper;
public static class GenericSort
{
  public static IQueryable<T> OrderByGeneric<T>(this IQueryable<T> query, Sort? sort)
    where T : class
  {
    if (sort == null ||
      Order.Unspecified == sort.Order ||
      sort.Order == null ||
      string.IsNullOrWhiteSpace(sort.By)) return query;

    string sortOrder = sort.Order == Order.Ascending ? "asc" : "desc";
    try
    {
      return query.OrderBy($"{sort.By} {sortOrder}");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Property not exist {0} {1}", sort.By, ex.Message);
      return query;
    }
  }
}