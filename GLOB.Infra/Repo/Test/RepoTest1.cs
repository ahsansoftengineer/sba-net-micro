using GLOB.App.Repo;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;

namespace GLOB.Infra.Repo;
public class RepoTest1 : RepoGeneric<Test1>, IRepoTest1
{
  private readonly AppDBContext _db;
  public RepoTest1(AppDBContext db): base(db)
  {
    _db = db;
  }
  // public void Update(Test1 entity)
  // {
  //   _db.Test1.Update(entity);
  // }
}