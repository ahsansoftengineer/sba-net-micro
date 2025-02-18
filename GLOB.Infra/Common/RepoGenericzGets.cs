using GLOB.Domain.Base;
using GLOB.Domain.Common;
using GLOB.Infra.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.PagedList;

namespace GLOB.Infra.Common;
public partial class RepoGenericz<T> 
{
  // Filter, OrderBy, Include
  public async Task<List<T>> Gets(
    Expression<Func<T, bool>>? expression = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    List<string>? includes = null)
  {
    IQueryable<T> query = _db;
    if (expression != null)
    {
      query = query.Where(expression);
    }

    query = query.IncluesByGeneric(includes);
    
    if (orderBy != null)
    {
      query = orderBy(query);
    }
    return await query.AsNoTracking().ToListAsync();
  }

  // Filter, OrderBy, Include, Pagination
  public async Task<PaginateResponse<T>> GetsPaginate<TDto>(
    PaginateRequestFilter<T, TDto>? req
  )
    where TDto : class
  {
    // if (req == null)
    // {
    //   req = new PaginateRequestFilter<T, TDto>()
    //   {
    //     PageNo = 1,
    //     PageSize = 10,
    //     Sort = new Sort() {
    //       By = "UpdatedAt",
    //       Order = Order.Descending
    //     },
    //     Filter = null
    //   };
    // }

    IQueryable<T> query = _db;
    // //query = query.FilterByGeneric<T, TDto>(req.Search);
    // //query = query.OrderByGeneric<T>(req.Sort);
    // // Simplified Form
    // query = query.FilterByGeneric(req.Filter);
    // query = query.OrderByGeneric(req.Sort);
    // query = query.IncluesByGeneric(req.includes);
    return await query
      .AsNoTracking()
      .ToPaginateAsync(req?.PageNo ?? 1, req?.PageSize ?? 10);
  }
}


/** 
 https://blog.zhaytam.com/2020/05/17/dynamic-sorting-filtering-csharp/

APPROACH 1.WITHOUT LIBRARY
MANUAL DYNAMIC SORTING
public IQueryable<Product> ApplyOrderBy(IQueryable<Product> query, string property)
{
  switch (property)
  {
  case "Name":
    return query.OrderBy(p => p.Name);
  case "Quantity":
    return query.OrderBy(p => p.Quantity);
  case "Price":
    return query.OrderBy(p => p.Price);
  default:
    return query;
  }
}

var query = _dbContext.Products.AsQueryable();
query = ApplyOrderBy(query, propertySentByUser);

MANUAL DYNAMIC FILTERING
public IQueryable<Product> ApplyFilter(IQueryable<Product> query, string property, object value)
{
  switch (property)
  {
  case "Name":
    return query.Where(p => p.Name.Contains(value.ToString()));
  case "Quantity":
    return query.Where(p => p.Quantity >= value);
  case "Price":
    return query.Where(p => p.Price >= value);
  default:
    return query;
  }
}
MANUAL DYNAMIC ADVANCE FILTER
(Product.Brand == "Nike" || Product.Brand == "Adidas")
&& (Product.Price >= 20 && Product.Price <= 100)
&& Product.Enabled



 APPROACH 2. WITH DYNAMIC.NET LIBRARY
 Dynamic.NET ->  TODO

 DYNAMIC SORTING
public async Task<IPagedList<T>> GetPagetListAlternate()
{
  var propertyGetter = DynamicExpressions.GetPropertyGetter<Product>(propertySentByUser);
  // ^ can be cached or even compiled to a Func<Product, object>
  var query = _dbContext.Products.AsQueryable().OrderBy(propertyGetter);
}

 DYNAMIC FILTERING
var predicate = DynamicExpressions.GetPredicate<Product>(propertySentByUser, operatorSentByUser, valueSentByUser);
// ^ can also be cached or compiled and used anywhere
var products = _dbContext.Products.AsQueryable().Where(predicate).ToList();
// ^ or FirstByDefault, Any, etc...

 DYNAMIC FILTERING LIBRARY APPROACH
var predicate = new DynamicFilterBuilder<Product>()
  .And("Enabled", FilterOperator.Equals, true)
  .And(b => b.And("Brand", FilterOperator.Equals, "Nike").Or("Brand", FilterOperator.Equals, "Adidas"))
  .And(b => b.And("Price", FilterOperator.GreaterThanOrEqual, 20).And("Price", FilterOperator.LessThanOrEqual, 100))
  .Build();

var products = _dbContext.Products.AsQueryable().Where(predicate).ToList()


 HOW DOES IT WORKS UNDER THE HOOD
public static Expression<Func<TEntity, object>> GetPropertyGetter<TEntity>(string property)
{
  if (property == null)
  throw new ArgumentNullException(nameof(property));

  var param = Expression.Parameter(typeof(TEntity));
  var prop = param.GetNestedProperty(property);
  var convertedProp = Expression.Convert(prop, typeof(object));
  return Expression.Lambda<Func<TEntity, object>>(convertedProp, param);
}
*/