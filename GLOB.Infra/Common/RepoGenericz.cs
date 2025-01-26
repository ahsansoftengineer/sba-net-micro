using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using X.PagedList;

namespace GLOB.Infra.Common;
public class RepoGenericz<T> : IRepoGenericz<T> where T : class
{
  private readonly AppDBContextz _context;
  private readonly DbSet<T> _db;
  public RepoGenericz(AppDBContextz context)
  {
    _context = context;
    _db = context.Set<T>();
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
  public async Task<T> Get(
   Expression<Func<T, bool>> expression,
   List<string>? includes = null)
  {
    IQueryable<T> query = _db;
    if (includes != null)
    {
      foreach (var item in includes)
      {
        query = query.Include(item);
      }
    }
    var result = await query.AsNoTracking().FirstOrDefaultAsync(expression);
    return result; //if (result != null) return result; //
  }

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

    if (includes != null)
    {
      foreach (var item in includes)
      {
        query = query.Include(item);
      }
    }

    if (orderBy != null)
    {
      query = orderBy(query);
    }
    return await query.AsNoTracking().ToListAsync();
  }
  public async Task<IPagedList<T>> Gets<TDto>(PaginateRequestFilter<T, TDto>? req)
    where TDto : class
  {
    if (req == null)
    {
      req = new PaginateRequestFilter<T, TDto>()
      {
        PageNo = 1,
        PageSize = 2,
        Sort = null,
        Search = null
      };
    }

    IQueryable<T> query = _db;
    //query = query.FilterByGeneric<T, TDto>(req.Search);
    //query = query.OrderByGeneric<T>(req.Sort);
    // Simplified Form
    query = query.FilterByGeneric(req.Search);
    query = query.OrderByGeneric(req.Sort);
    query = query.IncluesByGeneric(req.includes);
    return null;
    // return await query
    //   .AsNoTracking()
    //   .ToPagedListAsync(req.PageNo, req.PageSize);
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