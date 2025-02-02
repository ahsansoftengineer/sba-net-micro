// using GLOB.App.Repo;
// using GLOB.Apps.Common;
// using GLOB.Infra.Repo;

// namespace GLOB.Infra.Common;
// public partial class UnitOfWork : IUnitOfWork
// {
//   private readonly AppDBContext _db;
//   public UnitOfWork(AppDBContext db)
//   {
//     _db = db;

//     TestEntityInfra = new RepoTestEntityInfra(_db);
//   }
//   public void Save()
//   {
//     _db.SaveChanges();
//   }

// }