using System.Linq.Dynamic.Core;
using GLOB.Domain.Base;
using GLOB.Domain.Extension;

namespace GLOB.Infra.Helper;
public static partial class RepoExtensionActions
{
  public static IQueryable<T> ToExtOrderBy<T>(this IQueryable<T> query, Sort? sort)
    where T : class, IEntityBeta
  {
    if (sort == null || string.IsNullOrEmpty(sort?.By))
    {
      sort = new Sort()
      {
        By = "none",
        Order = Order.Ascending
      };
    }

    string sortOrder = sort?.Order == Order.Descending ? "desc" : "asc";
    try
    {
      if (!sort.By.HasValidProperty<T>())
      {
        sortOrder = "desc";
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