using System.Linq.Dynamic.Core;
using GLOB.Domain.Base;
using GLOB.Domain.Extension;

namespace GLOB.Infra.Helper;
public static class GenericSort
{
  public static IQueryable<T> OrderByGeneric<T>(this IQueryable<T> query, Sort? sort)
    where T : BetaEntity
  {
    if (sort == null || string.IsNullOrEmpty(sort?.By))
    {
      sort = new Sort()
      {
        By = "none",
        Order = Order.Unspecified
      };
    }

    string sortOrder = sort?.Order == Order.Descending ? "desc" : "asc";
    try
    {
      if (!sort.By.HasValidProperty<T>())
      {
        return query.OrderBy($"UpdatedAt {sortOrder}");
      }
      return query.OrderBy($"{sort.By} {sortOrder}");
    }
    catch (Exception ex)
    {
      Console.WriteLine("Property not exist {0} {1} on Type {2}", sort.By, ex.Message, nameof(T));
      return query;
    }
  }

}