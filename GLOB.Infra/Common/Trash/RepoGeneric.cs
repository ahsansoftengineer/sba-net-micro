// using System.Linq.Expressions;
// using GLOB.Apps.Common;
// using Microsoft.EntityFrameworkCore;

// namespace GLOB.Infra.Common;
// public class RepoGeneric<T> : IRepoGeneric<T> where T : class
// {
//   private readonly AppDBContext _db;
//   internal DbSet<T> dbSet;
//   public RepoGeneric(AppDBContext db)
//   {
//     _db = db;
//     dbSet = _db.Set<T>();
//   }

//   public void Add(T entity)
//   {
//     dbSet.Add(entity);
//   }

//   public void Update(T entity)
//   {
//     dbSet.Update(entity);
//   }
  
//   public void Remove(T entity)
//   {
//     _db.Remove(entity);
//   }
//   public T? Get(Expression<Func<T, bool>> filter, string? includes)
//   {
//     IQueryable<T> query = dbSet;
//     if (filter != null)
//     {
//       query = query.Where(filter);
//     }
//     // Include Should be Case Sensitive
//     if (!string.IsNullOrEmpty(includes))
//     {
//       var result = includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
//       foreach (var include in result)
//       {
//         query = query.Include(include);
//       }
//     }
//     return query.FirstOrDefault();
//   }
//   public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includes = null)
//   {
//     IQueryable<T> query = dbSet;
//     if (filter != null)
//     {
//       query = query.Where(filter);
//     }
//     // Include Should be Case Sensitive
//     if (!string.IsNullOrEmpty(includes))
//     {
//       var result = includes.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
//       foreach (var include in result)
//       {
//         query = query.Include(include);
//       }
//     }
//     return query.ToList();
//   }

//   public bool Any(Expression<Func<T, bool>>? filter = null)
//   {
//     return dbSet.Any(filter);
//   }

//   public void Save()
//   {
//     _db.SaveChanges();
//   }

// }