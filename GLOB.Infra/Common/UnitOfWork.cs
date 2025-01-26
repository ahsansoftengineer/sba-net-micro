using GLOB.App.Repo;
using GLOB.Apps.Common;
using GLOB.Infra.Repo;

namespace GLOB.Infra.Common;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDBContext _db;
    public IRepoTestEntity Test1 { get; private set; }

    public UnitOfWork(AppDBContext db)
    {
        _db = db;

        Test1 = new RepoTestEntity(_db);
    }

    public void Save()
    {
        _db.SaveChanges();
    }
}