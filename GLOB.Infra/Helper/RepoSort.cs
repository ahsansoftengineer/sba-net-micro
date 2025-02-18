using System.Linq.Dynamic.Core;
using GLOB.Domain.Base;
using GLOB.Domain.Extension;

namespace GLOB.Infra.Helper;
public static class GenericSort
{
  public static IQueryable<T> OrderByGeneric<T>(this IQueryable<T> query, Sort? sort)
    where T : BetaEntity
  {
    if (sort != null && Order.Unspecified == sort.Order || sort.Order == null)
    {
      sort.Order = Order.Ascending;
    }

    if (sort == null || !sort.By.HasValidProperty<T>())
    {
      query.OrderByDescending(x => x.UpdatedAt);
      return query;
    }

    string sortOrder = sort.Order == Order.Ascending ? "asc" : "desc";

    try
    {
      return query.OrderBy($"{sort.By} {sortOrder}");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Property not exist {0} {1} on Type {2}", sort.By, ex.Message, nameof(T));
      return query;
    }
  }
 
}