using System.Linq.Dynamic.Core;
using GLOB.Infra.Model.Base;
using GLOB.Infra.Utils.Extz;

namespace GLOB.Infra.Paginate;
public static partial class ExtQuery
{
  public static IQueryable<T> ToExtQueryOrderBy<T>(this IQueryable<T> query, Sort? sort)
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