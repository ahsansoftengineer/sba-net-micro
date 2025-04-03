using GLOB.Domain.Base;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.UOW;
public partial class UnitOfWorkz : IUnitOfWorkz
{
  public readonly DbContext _context;

  public UnitOfWorkz(DbContext context)
  {
    _context = context;
  }

  public async Task Save()
  {
    AddTimestamps();
    await _context.SaveChangesAsync();
  }
  // private IRepoGenericz<T> Got<T>() where T : EntityBase
  // {
  //   return new RepoGenericz<T>(_context);
  // }

  private void AddTimestamps()
  {
    var entities = _context.ChangeTracker.Entries()
      .Where(x => x.Entity is IEntityBeta && (x.State == EntityState.Added || x.State == EntityState.Modified));

    foreach (var entity in entities)
    {
      var now = DateTimeOffset.UtcNow; // current datetime
      Console.WriteLine(entity.State);
      if (entity.State == EntityState.Added)
      {
        ((IEntityBeta)entity.Entity).CreatedAt = now;
      }
    //EntityState.Detached, EntityState.Deleted, EntityState.Unchanged
    ((IEntityBeta)entity.Entity).UpdatedAt = now;
    }
  }
  public void Dispose()
  {
    _context.Dispose();
    GC.SuppressFinalize(this);
  }
}