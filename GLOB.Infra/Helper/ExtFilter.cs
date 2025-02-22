using GLOB.Domain.Extension;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection;

namespace GLOB.Infra.Helper;
public static partial class RepoExtensionActions
{
  public static IQueryable<T> ToExtFilter<T, TDtoSearch>(this IQueryable<T> source, TDtoSearch? DtoSearch)
    where T : class
    where TDtoSearch : class
  {
    if (DtoSearch == null) return source;

    //var dtoParam = Expression.Parameter(typeof(TDtoSearch), "TDtoSearch"); //
    var entityParam = Expression.Parameter(typeof(T), "TEntity");
    var dtoPropInfos = DtoSearch.GetType()
      .GetProperties(BindingFlags.Public | BindingFlags.Instance)
      .Where(p => p.GetValue(DtoSearch) != null); // && p.PropertyType.IsValueType

    var predicate = PredicateBuilder.New<T>();

    foreach (var dtoPropInfo in dtoPropInfos)
    {
      if (!dtoPropInfo.Name.HasValidProperty<T>())
      {
        continue;
      }
      MemberExpression? entityProp = null;
      try
      {
        entityProp = Expression.Property(entityParam, dtoPropInfo.Name);
      }
      catch (Exception e)
      {
        Console.WriteLine("Property not Exist {0} Message : {1}", dtoPropInfo.Name, e.Message);
      }
      if (entityProp != null)
      {
        var entityValue = dtoPropInfo.GetValue(DtoSearch);
        var constant = Expression.Constant(entityValue, entityProp.Type);

        if (!string.IsNullOrWhiteSpace(entityValue?.ToString()))
        {
          if (entityValue.GetType() == typeof(string))
          {
            predicate = predicate.And(p => EF.Functions.Like(
            EF.Property<string>(p, dtoPropInfo.Name),
            $"%{entityValue}%")
             );
          }
          else
          {
            var comparison = Expression.Equal(entityProp, constant);
            var lambda = Expression.Lambda(comparison, entityParam);
            predicate = predicate.And((Expression<Func<T, bool>>)lambda);
          }

        }
      }
    }
    if (predicate.Parameters.Count > 0)
      return source.Where(predicate);
    return source;
  }
}