using GLOB.App.Repo;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;

namespace GLOB.Infra.Repo;
public class RepoTestEntity : RepoGeneric<TestEntity>, IRepoTestEntity
{
  private readonly AppDBContext _db;
  public RepoTestEntity(AppDBContext db): base(db)
  {
    _db = db;
  }
  // public void Update(Test1 entity)
  // {
  //   _db.Test1.Update(entity);
  // }
}