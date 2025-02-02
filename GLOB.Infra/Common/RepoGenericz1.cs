using GLOB.Apps.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GLOB.Infra.Common;
public partial class RepoGenericz<T> : IRepoGenericz<T> where T : class
{
  private readonly AppDBContextz _context;
  private readonly DbSet<T> _db;
  public RepoGenericz(AppDBContextz context)
  {
    _context = context;
    _db = context.Set<T>();
  }

  public bool Any(Expression<Func<T, bool>>? filter = null)
  {
    return _db.Any(filter);
  }

  public async Task Delete(int id)
  {
    var entity = await _db.FindAsync(id);
    if (entity != null) _db.Remove(entity);
  }

  public void DeleteRange(IEnumerable<T> entities)
  {
    _db.RemoveRange(entities);
  }
  public async Task Insert(T entity)
  {
    await _db.AddAsync(entity);
    //await _context.SaveChangesAsync();
  }

  public async Task InsertRange(IEnumerable<T> entities)
  {
    await _db.AddRangeAsync(entities);
  }

  public void Update(T entity)
  {
    _db.Attach(entity);
    _context.Entry(entity).State = EntityState.Modified;
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